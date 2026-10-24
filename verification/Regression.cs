using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using ACE.Classes;
using ACE.Classes.ACE;
using EList = ACE.Elements.eList.eList;

internal static class Regression
{
    static int passed;
    static void Check(bool result, string name)
    {
        if (!result) throw new Exception("FAIL: " + name);
        passed++; Console.WriteLine("PASS: " + name);
    }
    static void Throws<T>(Action action, string name) where T : Exception
    {
        try { action(); } catch (T) { Check(true, name); return; }
        throw new Exception("FAIL (no expected exception): " + name);
    }
    static object Read(byte[] bytes, string type)
    {
        using (var reader = new BinaryReader(new MemoryStream(bytes))) return EList.readValue(reader, type);
    }
    [STAThread]
    static int Main()
    {
        try
        {
            Check((int)Read(BitConverter.GetBytes(123), "int") == 123, "int read");
            Check((short)Read(new byte[] {255, 255}, "int16") == -1, "signed 16-bit read");
            Check((ushort)Read(new byte[] {255, 255}, "uint16") == 65535, "unsigned 16-bit read");
            Check(Object.ReferenceEquals(Read(BitConverter.GetBytes(123), "int"), Read(BitConverter.GetBytes(123), "int")), "shared immutable integer boxes");
            Check(Object.ReferenceEquals(Read(BitConverter.GetBytes(1f), "float"), Read(BitConverter.GetBytes(1f), "float")), "shared float one");
            float negativeZero = (float)Read(new byte[] {0, 0, 0, 128}, "float");
            Check(BitConverter.ToInt32(BitConverter.GetBytes(negativeZero), 0) == int.MinValue, "negative zero preserved");
            foreach (int bits in new[] {0x7fc00001, unchecked((int)0xffc00001), 0x7f800000, unchecked((int)0xff800000)})
                Check(BitConverter.ToInt32(BitConverter.GetBytes((float)Read(BitConverter.GetBytes(bits), "float")), 0) == bits, "float bit roundtrip " + bits);
            byte[] a = (byte[])Read(new byte[] {1, 2}, "byte:2");
            byte[] b = (byte[])Read(new byte[] {1, 2}, "byte:2"); a[0] = 9;
            Check(b[0] == 1, "mutable byte fields remain independent");
            Throws<InvalidDataException>(() => Read(new byte[1], "byte:2"), "truncated field rejected");
            Throws<InvalidDataException>(() => Read(new byte[1], "byte:-1"), "negative field rejected");
            Throws<InvalidDataException>(() => Read(new byte[4], "x"), "unknown short type rejected");
            using (var stream = new MemoryStream(new byte[] {255,255,255,255}))
            using (var reader = new BinaryReader(stream))
            {
                Throws<InvalidDataException>(() => EList.GetConversationListLength(reader), "negative conversation count rejected");
                Check(stream.Position == 0, "probe position restored after failure");
            }
            // One conversation, one window, two UTF-16 code units and one option.
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream); writer.Write(1); writer.Write(new byte[132]);
                writer.Write(1); writer.Write(new byte[8]); writer.Write(2); writer.Write(new byte[4]);
                writer.Write(1); writer.Write(new byte[136]); writer.Flush(); stream.Position = 0;
                var reader = new BinaryReader(stream);
                Check(EList.GetConversationListLength(reader) == stream.Length && stream.Position == 0, "complete conversation length and position");
            }
            Throws<ArgumentOutOfRangeException>(() => new FileBasedUndoManager("regression", 0), "history capacity validated");
            using (var first = new FileBasedUndoManager("same-editor", 2))
            using (var second = new FileBasedUndoManager("same-editor", 2))
            {
                first.PushUndo(new byte[] {1}); second.PushUndo(new byte[] {9});
                Check(first.Undo(new byte[] {2})[0] == 1, "independent undo directories");
                Check(first.Redo(new byte[] {1})[0] == 2, "redo roundtrip");
                first.PushUndo(new byte[] {3}); first.PushUndo(new byte[] {4});
                Check(first.UndoCount == 2, "history eviction capacity");
                Check(first.Undo(new byte[] {5})[0] == 4, "newest snapshot restored");
                first.PushUndo(new byte[] {6}); Check(!first.CanRedo, "new edit clears redo");
                var field = typeof(FileBasedUndoManager).GetField("string_0", BindingFlags.NonPublic | BindingFlags.Instance);
                string folder = (string)field.GetValue(second);
                File.Delete(Directory.GetFiles(folder, "*.undo").Single());
                Throws<FileNotFoundException>(() => second.Undo(new byte[] {10}), "missing undo raises failure");
                Check(second.UndoCount == 1 && second.RedoCount == 0, "I/O failure retains history stacks");
            }
            var service = new IconsService();
            var names = new List<string> {"red", "green"};
            // Two RGB24 pixels and DWORD row padding.
            var icons = service.ParseIcons(new byte[] {0,0,255, 0,255,0, 0,0}, 2, 1, PixelFormat.Format24bppRgb, names, 1, 2, 2, 1, 1);
            try
            {
                Check(icons["red"].GetPixel(0,0).ToArgb() == Color.Red.ToArgb(), "RGB24 converted to opaque RGBA");
                Check(icons["green"].GetPixel(0,0).G == 255, "RGB24 second pixel");
                using (var atlas = IconsService.CreateScreenAdaptedImageUnsafe(icons, names, 2, 1, 1, 2))
                    Check(atlas.GetPixel(0,0).R == 255 && atlas.GetPixel(1,0).G == 255, "atlas rebuild pixels");
            }
            finally { foreach (var icon in icons.Values) icon.Dispose(); }
            Throws<InvalidDataException>(() => service.ParseIcons(new byte[1], 2, 1, PixelFormat.Format24bppRgb, names, 1, 2, 2, 1, 1), "truncated atlas rejected");
            Console.WriteLine("ALL PASSED: " + passed); return 0;
        }
        catch (Exception error) { Console.Error.WriteLine(error); return 1; }
    }
}
