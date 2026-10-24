using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ACE.Classes.Localization;

// Control-name catalogs for localized forms. No user data is translated.
internal static class SimplifiedChineseForms
{
    private sealed class Catalog
    {
        public Dictionary<string, string> controls = new Dictionary<string, string>();
        public Dictionary<string, string> tooltips = new Dictionary<string, string>();
        public Dictionary<string, string[]> lists = new Dictionary<string, string[]>();
    }
    private static readonly object Gate = new object();
    private static readonly Dictionary<string, Catalog> Cache = new Dictionary<string, Catalog>(StringComparer.Ordinal);
    private static readonly Queue<string> Order = new Queue<string>();
    private static readonly ConditionalWeakTable<Form, ToolTip> FormToolTips = new ConditionalWeakTable<Form, ToolTip>();
    private const int CacheLimit = 24;

    private static Catalog Load(string locale, string name)
    {
        if ((locale != "cn" && locale != "pt-BR") || string.IsNullOrWhiteSpace(name) || name.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0 || name.Contains("/") || name.Contains("\\")) return null;
        string cacheKey = locale + "/" + name;
        lock (Gate)
        {
            if (Cache.TryGetValue(cacheKey, out Catalog cached)) return cached;
            string path = System.IO.Path.Combine(Application.StartupPath, "i18n", locale, "forms", name + ".json");
            if (!File.Exists(path)) return null;
            Catalog result;
            try
            {
                using (var input = File.OpenRead(path))
                {
                    if (input.Length > 1024 * 1024) throw new InvalidDataException("中文窗口资源超过 1 MiB 上限。");
                    using (var text = new StreamReader(input, Encoding.UTF8))
                    using (var json = new JsonTextReader(text) { MaxDepth = 8 })
                        result = new JsonSerializer().Deserialize<Catalog>(json);
                }
                if (result == null || result.controls == null || result.tooltips == null || result.lists == null)
                    throw new InvalidDataException("中文窗口资源结构无效。");
            }
            catch (Exception error) when (error is IOException || error is JsonException || error is UnauthorizedAccessException)
            {
                Trace.TraceWarning("中文资源加载失败：{0}；{1}", name, error.Message);
                return null;
            }
            if (Cache.Count >= CacheLimit) Cache.Remove(Order.Dequeue());
            Cache.Add(cacheKey, result); Order.Enqueue(cacheKey);
            return result;
        }
    }

    internal static void Apply(Form form, ToolTip tip, string locale)
    {
        if (form == null || form.IsDisposed) return;
        string typeName = form.GetType().Name;
        Catalog catalog = Load(locale, form.Name) ?? Load(locale, typeName);
        if (catalog == null) return;
        if (tip == null && catalog.tooltips.Count > 0)
            tip = FormToolTips.GetValue(form, owner =>
            {
                var created = new ToolTip { AutoPopDelay = 12000 };
                owner.Disposed += (sender, args) => created.Dispose();
                return created;
            });
        if (catalog.controls.TryGetValue(form.Name, out string title) || catalog.controls.TryGetValue(typeName, out title)) form.Text = title;
        form.SuspendLayout();
        try { foreach (Control control in form.Controls) ApplyControl(catalog, control, tip); ApplyMenu(catalog, form.ContextMenuStrip); }
        finally { form.ResumeLayout(true); }
    }

    private static void ApplyControl(Catalog catalog, Control control, ToolTip tip)
    {
        // A blank caption can be intentional (for example, an icon-only search checkbox).
        // Keep it blank and translate its tooltip instead of expanding it over nearby controls.
        if (!(control is TextBoxBase) && !(control is ComboBox) && !(control is ListBox) &&
            !string.IsNullOrWhiteSpace(control.Text) && catalog.controls.TryGetValue(control.Name, out string text)) control.Text = text;
        if (tip != null && catalog.tooltips.TryGetValue(control.Name, out string help)) tip.SetToolTip(control, help);
        if (control is ToolStrip strip) foreach (ToolStripItem item in strip.Items) ApplyItem(catalog, item);
        if (control is DataGridView grid)
            foreach (DataGridViewColumn col in grid.Columns)
                if (catalog.controls.TryGetValue(col.Name, out string header)) col.HeaderText = header;
        if (control is ListView view)
            foreach (ColumnHeader col in view.Columns)
                if (catalog.controls.TryGetValue(col.Name, out string header)) col.Text = header;
        if (catalog.lists.TryGetValue(control.Name, out string[] values) && values != null)
        {
            if (control is ComboBox combo && combo.DataSource == null && combo.Items.Count == values.Length)
            {
                bool strings = true; foreach (object item in combo.Items) strings &= item is string;
                if (strings) { combo.BeginUpdate(); try { for (int i = 0; i < values.Length; i++) combo.Items[i] = values[i]; } finally { combo.EndUpdate(); } }
            }
            else if (control is ListBox list && list.DataSource == null && list.Items.Count == values.Length)
            {
                bool strings = true; foreach (object item in list.Items) strings &= item is string;
                if (strings) { list.BeginUpdate(); try { for (int i = 0; i < values.Length; i++) list.Items[i] = values[i]; } finally { list.EndUpdate(); } }
            }
        }
        ApplyMenu(catalog, control.ContextMenuStrip);
        foreach (Control child in control.Controls) ApplyControl(catalog, child, tip);
    }

    private static void ApplyMenu(Catalog catalog, ContextMenuStrip menu)
    {
        if (menu != null) foreach (ToolStripItem item in menu.Items) ApplyItem(catalog, item);
    }
    private static void ApplyItem(Catalog catalog, ToolStripItem item)
    {
        if (!(item is ToolStripControlHost) && !string.IsNullOrWhiteSpace(item.Text) &&
            catalog.controls.TryGetValue(item.Name, out string text)) item.Text = text;
        if (catalog.tooltips.TryGetValue(item.Name, out string help)) item.ToolTipText = help;
        if (item is ToolStripDropDownItem drop) foreach (ToolStripItem child in drop.DropDownItems) ApplyItem(catalog, child);
    }
}
