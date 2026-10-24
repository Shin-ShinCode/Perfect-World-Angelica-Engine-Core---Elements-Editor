// TODO(recovered): materialized compiler anonymous types.
// ILSpy emitted empty stubs for these <>f__AnonymousTypeN classes; the editor
// references them by name in method signatures / cached-lambda Func<> fields, so
// they are reconstructed here as real generic records with a type-inferring
// Create(...) factory (the original `new { ... }` projections are rewritten to it).
using System.Collections.Generic;

internal sealed class _003C_003Ef__AnonymousType1<T1, T2>
{
    public T1 File { get; }
    public T2 Version { get; }
    public _003C_003Ef__AnonymousType1(T1 a1, T2 a2)
    {
        File = a1;
        Version = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType1<T1, T2> o && EqualityComparer<T1>.Default.Equals(File, o.File) && EqualityComparer<T2>.Default.Equals(Version, o.Version);
    public override int GetHashCode() { int h=17; h=h*31+(File?.GetHashCode() ?? 0); h=h*31+(Version?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType1
{
    public static _003C_003Ef__AnonymousType1<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType1<T1, T2>(a1, a2);
}

internal sealed class _003C_003Ef__AnonymousType21<T1, T2, T3, T4>
{
    public T1 index { get; }
    public T2 name { get; }
    public T3 item_count { get; }
    public T4 field_count { get; }
    public _003C_003Ef__AnonymousType21(T1 a1, T2 a2, T3 a3, T4 a4)
    {
        index = a1;
        name = a2;
        item_count = a3;
        field_count = a4;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType21<T1, T2, T3, T4> o && EqualityComparer<T1>.Default.Equals(index, o.index) && EqualityComparer<T2>.Default.Equals(name, o.name) && EqualityComparer<T3>.Default.Equals(item_count, o.item_count) && EqualityComparer<T4>.Default.Equals(field_count, o.field_count);
    public override int GetHashCode() { int h=17; h=h*31+(index?.GetHashCode() ?? 0); h=h*31+(name?.GetHashCode() ?? 0); h=h*31+(item_count?.GetHashCode() ?? 0); h=h*31+(field_count?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType21
{
    public static _003C_003Ef__AnonymousType21<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 a1, T2 a2, T3 a3, T4 a4)
        => new _003C_003Ef__AnonymousType21<T1, T2, T3, T4>(a1, a2, a3, a4);
}

internal sealed class _003C_003Ef__AnonymousType23<T1, T2, T3, T4>
{
    public T1 index { get; }
    public T2 name { get; }
    public T3 fields { get; }
    public T4 items { get; }
    public _003C_003Ef__AnonymousType23(T1 a1, T2 a2, T3 a3, T4 a4)
    {
        index = a1;
        name = a2;
        fields = a3;
        items = a4;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType23<T1, T2, T3, T4> o && EqualityComparer<T1>.Default.Equals(index, o.index) && EqualityComparer<T2>.Default.Equals(name, o.name) && EqualityComparer<T3>.Default.Equals(fields, o.fields) && EqualityComparer<T4>.Default.Equals(items, o.items);
    public override int GetHashCode() { int h=17; h=h*31+(index?.GetHashCode() ?? 0); h=h*31+(name?.GetHashCode() ?? 0); h=h*31+(fields?.GetHashCode() ?? 0); h=h*31+(items?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType23
{
    public static _003C_003Ef__AnonymousType23<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 a1, T2 a2, T3 a3, T4 a4)
        => new _003C_003Ef__AnonymousType23<T1, T2, T3, T4>(a1, a2, a3, a4);
}

internal sealed class _003C_003Ef__AnonymousType24<T1, T2, T3>
{
    public T1 index { get; }
    public T2 id { get; }
    public T3 values { get; }
    public _003C_003Ef__AnonymousType24(T1 a1, T2 a2, T3 a3)
    {
        index = a1;
        id = a2;
        values = a3;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType24<T1, T2, T3> o && EqualityComparer<T1>.Default.Equals(index, o.index) && EqualityComparer<T2>.Default.Equals(id, o.id) && EqualityComparer<T3>.Default.Equals(values, o.values);
    public override int GetHashCode() { int h=17; h=h*31+(index?.GetHashCode() ?? 0); h=h*31+(id?.GetHashCode() ?? 0); h=h*31+(values?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType24
{
    public static _003C_003Ef__AnonymousType24<T1, T2, T3> Create<T1, T2, T3>(T1 a1, T2 a2, T3 a3)
        => new _003C_003Ef__AnonymousType24<T1, T2, T3>(a1, a2, a3);
}

internal sealed class _003C_003Ef__AnonymousType25<T1, T2, T3>
{
    public T1 id { get; }
    public T2 name { get; }
    public T3 sub_count { get; }
    public _003C_003Ef__AnonymousType25(T1 a1, T2 a2, T3 a3)
    {
        id = a1;
        name = a2;
        sub_count = a3;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType25<T1, T2, T3> o && EqualityComparer<T1>.Default.Equals(id, o.id) && EqualityComparer<T2>.Default.Equals(name, o.name) && EqualityComparer<T3>.Default.Equals(sub_count, o.sub_count);
    public override int GetHashCode() { int h=17; h=h*31+(id?.GetHashCode() ?? 0); h=h*31+(name?.GetHashCode() ?? 0); h=h*31+(sub_count?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType25
{
    public static _003C_003Ef__AnonymousType25<T1, T2, T3> Create<T1, T2, T3>(T1 a1, T2 a2, T3 a3)
        => new _003C_003Ef__AnonymousType25<T1, T2, T3>(a1, a2, a3);
}

internal sealed class _003C_003Ef__AnonymousType27<T1, T2, T3>
{
    public T1 id { get; }
    public T2 version { get; }
    public T3 trigger_count { get; }
    public _003C_003Ef__AnonymousType27(T1 a1, T2 a2, T3 a3)
    {
        id = a1;
        version = a2;
        trigger_count = a3;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType27<T1, T2, T3> o && EqualityComparer<T1>.Default.Equals(id, o.id) && EqualityComparer<T2>.Default.Equals(version, o.version) && EqualityComparer<T3>.Default.Equals(trigger_count, o.trigger_count);
    public override int GetHashCode() { int h=17; h=h*31+(id?.GetHashCode() ?? 0); h=h*31+(version?.GetHashCode() ?? 0); h=h*31+(trigger_count?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType27
{
    public static _003C_003Ef__AnonymousType27<T1, T2, T3> Create<T1, T2, T3>(T1 a1, T2 a2, T3 a3)
        => new _003C_003Ef__AnonymousType27<T1, T2, T3>(a1, a2, a3);
}

internal sealed class _003C_003Ef__AnonymousType41<T1, T2, T3>
{
    public T1 source_id { get; }
    public T2 source_index { get; }
    public T3 new_id { get; }
    public _003C_003Ef__AnonymousType41(T1 a1, T2 a2, T3 a3)
    {
        source_id = a1;
        source_index = a2;
        new_id = a3;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType41<T1, T2, T3> o && EqualityComparer<T1>.Default.Equals(source_id, o.source_id) && EqualityComparer<T2>.Default.Equals(source_index, o.source_index) && EqualityComparer<T3>.Default.Equals(new_id, o.new_id);
    public override int GetHashCode() { int h=17; h=h*31+(source_id?.GetHashCode() ?? 0); h=h*31+(source_index?.GetHashCode() ?? 0); h=h*31+(new_id?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType41
{
    public static _003C_003Ef__AnonymousType41<T1, T2, T3> Create<T1, T2, T3>(T1 a1, T2 a2, T3 a3)
        => new _003C_003Ef__AnonymousType41<T1, T2, T3>(a1, a2, a3);
}

internal sealed class _003C_003Ef__AnonymousType43<T1, T2>
{
    public T1 itemId { get; }
    public T2 itemIndex { get; }
    public _003C_003Ef__AnonymousType43(T1 a1, T2 a2)
    {
        itemId = a1;
        itemIndex = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType43<T1, T2> o && EqualityComparer<T1>.Default.Equals(itemId, o.itemId) && EqualityComparer<T2>.Default.Equals(itemIndex, o.itemIndex);
    public override int GetHashCode() { int h=17; h=h*31+(itemId?.GetHashCode() ?? 0); h=h*31+(itemIndex?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType43
{
    public static _003C_003Ef__AnonymousType43<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType43<T1, T2>(a1, a2);
}

internal sealed class _003C_003Ef__AnonymousType45<T1, T2>
{
    public T1 item_id { get; }
    public T2 item_index { get; }
    public _003C_003Ef__AnonymousType45(T1 a1, T2 a2)
    {
        item_id = a1;
        item_index = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType45<T1, T2> o && EqualityComparer<T1>.Default.Equals(item_id, o.item_id) && EqualityComparer<T2>.Default.Equals(item_index, o.item_index);
    public override int GetHashCode() { int h=17; h=h*31+(item_id?.GetHashCode() ?? 0); h=h*31+(item_index?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType45
{
    public static _003C_003Ef__AnonymousType45<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType45<T1, T2>(a1, a2);
}

internal sealed class _003C_003Ef__AnonymousType47<T1, T2, T3, T4>
{
    public T1 item_id { get; }
    public T2 item_index { get; }
    public T3 old_name { get; }
    public T4 new_name { get; }
    public _003C_003Ef__AnonymousType47(T1 a1, T2 a2, T3 a3, T4 a4)
    {
        item_id = a1;
        item_index = a2;
        old_name = a3;
        new_name = a4;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType47<T1, T2, T3, T4> o && EqualityComparer<T1>.Default.Equals(item_id, o.item_id) && EqualityComparer<T2>.Default.Equals(item_index, o.item_index) && EqualityComparer<T3>.Default.Equals(old_name, o.old_name) && EqualityComparer<T4>.Default.Equals(new_name, o.new_name);
    public override int GetHashCode() { int h=17; h=h*31+(item_id?.GetHashCode() ?? 0); h=h*31+(item_index?.GetHashCode() ?? 0); h=h*31+(old_name?.GetHashCode() ?? 0); h=h*31+(new_name?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType47
{
    public static _003C_003Ef__AnonymousType47<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 a1, T2 a2, T3 a3, T4 a4)
        => new _003C_003Ef__AnonymousType47<T1, T2, T3, T4>(a1, a2, a3, a4);
}

internal sealed class _003C_003Ef__AnonymousType52<T1, T2, T3, T4>
{
    public T1 item_id { get; }
    public T2 item_index { get; }
    public T3 old_value { get; }
    public T4 new_value { get; }
    public _003C_003Ef__AnonymousType52(T1 a1, T2 a2, T3 a3, T4 a4)
    {
        item_id = a1;
        item_index = a2;
        old_value = a3;
        new_value = a4;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType52<T1, T2, T3, T4> o && EqualityComparer<T1>.Default.Equals(item_id, o.item_id) && EqualityComparer<T2>.Default.Equals(item_index, o.item_index) && EqualityComparer<T3>.Default.Equals(old_value, o.old_value) && EqualityComparer<T4>.Default.Equals(new_value, o.new_value);
    public override int GetHashCode() { int h=17; h=h*31+(item_id?.GetHashCode() ?? 0); h=h*31+(item_index?.GetHashCode() ?? 0); h=h*31+(old_value?.GetHashCode() ?? 0); h=h*31+(new_value?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType52
{
    public static _003C_003Ef__AnonymousType52<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 a1, T2 a2, T3 a3, T4 a4)
        => new _003C_003Ef__AnonymousType52<T1, T2, T3, T4>(a1, a2, a3, a4);
}

internal sealed class _003C_003Ef__AnonymousType65<T1, T2, T3>
{
    public T1 source_id { get; }
    public T2 new_id { get; }
    public T3 new_name { get; }
    public _003C_003Ef__AnonymousType65(T1 a1, T2 a2, T3 a3)
    {
        source_id = a1;
        new_id = a2;
        new_name = a3;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType65<T1, T2, T3> o && EqualityComparer<T1>.Default.Equals(source_id, o.source_id) && EqualityComparer<T2>.Default.Equals(new_id, o.new_id) && EqualityComparer<T3>.Default.Equals(new_name, o.new_name);
    public override int GetHashCode() { int h=17; h=h*31+(source_id?.GetHashCode() ?? 0); h=h*31+(new_id?.GetHashCode() ?? 0); h=h*31+(new_name?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType65
{
    public static _003C_003Ef__AnonymousType65<T1, T2, T3> Create<T1, T2, T3>(T1 a1, T2 a2, T3 a3)
        => new _003C_003Ef__AnonymousType65<T1, T2, T3>(a1, a2, a3);
}

internal sealed class _003C_003Ef__AnonymousType69<T1, T2, T3>
{
    public T1 task_id { get; }
    public T2 depth { get; }
    public T3 parent_id { get; }
    public _003C_003Ef__AnonymousType69(T1 a1, T2 a2, T3 a3)
    {
        task_id = a1;
        depth = a2;
        parent_id = a3;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType69<T1, T2, T3> o && EqualityComparer<T1>.Default.Equals(task_id, o.task_id) && EqualityComparer<T2>.Default.Equals(depth, o.depth) && EqualityComparer<T3>.Default.Equals(parent_id, o.parent_id);
    public override int GetHashCode() { int h=17; h=h*31+(task_id?.GetHashCode() ?? 0); h=h*31+(depth?.GetHashCode() ?? 0); h=h*31+(parent_id?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType69
{
    public static _003C_003Ef__AnonymousType69<T1, T2, T3> Create<T1, T2, T3>(T1 a1, T2 a2, T3 a3)
        => new _003C_003Ef__AnonymousType69<T1, T2, T3>(a1, a2, a3);
}

internal sealed class _003C_003Ef__AnonymousType74<T1, T2>
{
    public T1 old_id { get; }
    public T2 new_id { get; }
    public _003C_003Ef__AnonymousType74(T1 a1, T2 a2)
    {
        old_id = a1;
        new_id = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType74<T1, T2> o && EqualityComparer<T1>.Default.Equals(old_id, o.old_id) && EqualityComparer<T2>.Default.Equals(new_id, o.new_id);
    public override int GetHashCode() { int h=17; h=h*31+(old_id?.GetHashCode() ?? 0); h=h*31+(new_id?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType74
{
    public static _003C_003Ef__AnonymousType74<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType74<T1, T2>(a1, a2);
}

internal sealed class _003C_003Ef__AnonymousType82<T1, T2>
{
    public T1 id { get; }
    public T2 trigger_count { get; }
    public _003C_003Ef__AnonymousType82(T1 a1, T2 a2)
    {
        id = a1;
        trigger_count = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType82<T1, T2> o && EqualityComparer<T1>.Default.Equals(id, o.id) && EqualityComparer<T2>.Default.Equals(trigger_count, o.trigger_count);
    public override int GetHashCode() { int h=17; h=h*31+(id?.GetHashCode() ?? 0); h=h*31+(trigger_count?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType82
{
    public static _003C_003Ef__AnonymousType82<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType82<T1, T2>(a1, a2);
}

internal sealed class _003C_003Ef__AnonymousType86<T1, T2>
{
    public T1 id { get; }
    public T2 name { get; }
    public _003C_003Ef__AnonymousType86(T1 a1, T2 a2)
    {
        id = a1;
        name = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType86<T1, T2> o && EqualityComparer<T1>.Default.Equals(id, o.id) && EqualityComparer<T2>.Default.Equals(name, o.name);
    public override int GetHashCode() { int h=17; h=h*31+(id?.GetHashCode() ?? 0); h=h*31+(name?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType86
{
    public static _003C_003Ef__AnonymousType86<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType86<T1, T2>(a1, a2);
}

internal sealed class _003C_003Ef__AnonymousType98<T1, T2, T3, T4, T5>
{
    public T1 index { get; }
    public T2 id { get; }
    public T3 trigger_id { get; }
    public T4 name { get; }
    public T5 amount { get; }
    public _003C_003Ef__AnonymousType98(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
    {
        index = a1;
        id = a2;
        trigger_id = a3;
        name = a4;
        amount = a5;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType98<T1, T2, T3, T4, T5> o && EqualityComparer<T1>.Default.Equals(index, o.index) && EqualityComparer<T2>.Default.Equals(id, o.id) && EqualityComparer<T3>.Default.Equals(trigger_id, o.trigger_id) && EqualityComparer<T4>.Default.Equals(name, o.name) && EqualityComparer<T5>.Default.Equals(amount, o.amount);
    public override int GetHashCode() { int h=17; h=h*31+(index?.GetHashCode() ?? 0); h=h*31+(id?.GetHashCode() ?? 0); h=h*31+(trigger_id?.GetHashCode() ?? 0); h=h*31+(name?.GetHashCode() ?? 0); h=h*31+(amount?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType98
{
    public static _003C_003Ef__AnonymousType98<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
        => new _003C_003Ef__AnonymousType98<T1, T2, T3, T4, T5>(a1, a2, a3, a4, a5);
}

internal sealed class _003C_003Ef__AnonymousType103<T1, T2>
{
    public T1 index { get; }
    public T2 clone { get; }
    public _003C_003Ef__AnonymousType103(T1 a1, T2 a2)
    {
        index = a1;
        clone = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType103<T1, T2> o && EqualityComparer<T1>.Default.Equals(index, o.index) && EqualityComparer<T2>.Default.Equals(clone, o.clone);
    public override int GetHashCode() { int h=17; h=h*31+(index?.GetHashCode() ?? 0); h=h*31+(clone?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType103
{
    public static _003C_003Ef__AnonymousType103<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType103<T1, T2>(a1, a2);
}

internal sealed class _003C_003Ef__AnonymousType105<T1, T2>
{
    public T1 source_index { get; }
    public T2 first_id { get; }
    public _003C_003Ef__AnonymousType105(T1 a1, T2 a2)
    {
        source_index = a1;
        first_id = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType105<T1, T2> o && EqualityComparer<T1>.Default.Equals(source_index, o.source_index) && EqualityComparer<T2>.Default.Equals(first_id, o.first_id);
    public override int GetHashCode() { int h=17; h=h*31+(source_index?.GetHashCode() ?? 0); h=h*31+(first_id?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType105
{
    public static _003C_003Ef__AnonymousType105<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType105<T1, T2>(a1, a2);
}

internal sealed class _003C_003Ef__AnonymousType109<T1, T2, T3, T4>
{
    public T1 source_index { get; }
    public T2 trigger_id { get; }
    public T3 gm_id { get; }
    public T4 name { get; }
    public _003C_003Ef__AnonymousType109(T1 a1, T2 a2, T3 a3, T4 a4)
    {
        source_index = a1;
        trigger_id = a2;
        gm_id = a3;
        name = a4;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType109<T1, T2, T3, T4> o && EqualityComparer<T1>.Default.Equals(source_index, o.source_index) && EqualityComparer<T2>.Default.Equals(trigger_id, o.trigger_id) && EqualityComparer<T3>.Default.Equals(gm_id, o.gm_id) && EqualityComparer<T4>.Default.Equals(name, o.name);
    public override int GetHashCode() { int h=17; h=h*31+(source_index?.GetHashCode() ?? 0); h=h*31+(trigger_id?.GetHashCode() ?? 0); h=h*31+(gm_id?.GetHashCode() ?? 0); h=h*31+(name?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType109
{
    public static _003C_003Ef__AnonymousType109<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 a1, T2 a2, T3 a3, T4 a4)
        => new _003C_003Ef__AnonymousType109<T1, T2, T3, T4>(a1, a2, a3, a4);
}

internal sealed class _003C_003Ef__AnonymousType111<T1, T2, T3>
{
    public T1 source_index { get; }
    public T2 id { get; }
    public T3 trigger_id { get; }
    public _003C_003Ef__AnonymousType111(T1 a1, T2 a2, T3 a3)
    {
        source_index = a1;
        id = a2;
        trigger_id = a3;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType111<T1, T2, T3> o && EqualityComparer<T1>.Default.Equals(source_index, o.source_index) && EqualityComparer<T2>.Default.Equals(id, o.id) && EqualityComparer<T3>.Default.Equals(trigger_id, o.trigger_id);
    public override int GetHashCode() { int h=17; h=h*31+(source_index?.GetHashCode() ?? 0); h=h*31+(id?.GetHashCode() ?? 0); h=h*31+(trigger_id?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType111
{
    public static _003C_003Ef__AnonymousType111<T1, T2, T3> Create<T1, T2, T3>(T1 a1, T2 a2, T3 a3)
        => new _003C_003Ef__AnonymousType111<T1, T2, T3>(a1, a2, a3);
}

internal sealed class _003C_003Ef__AnonymousType149<T1, T2>
{
    public T1 Item { get; }
    public T2 Index { get; }
    public _003C_003Ef__AnonymousType149(T1 a1, T2 a2)
    {
        Item = a1;
        Index = a2;
    }
    public override bool Equals(object obj) => obj is _003C_003Ef__AnonymousType149<T1, T2> o && EqualityComparer<T1>.Default.Equals(Item, o.Item) && EqualityComparer<T2>.Default.Equals(Index, o.Index);
    public override int GetHashCode() { int h=17; h=h*31+(Item?.GetHashCode() ?? 0); h=h*31+(Index?.GetHashCode() ?? 0); return h; }
}
internal static class _003C_003Ef__AnonymousType149
{
    public static _003C_003Ef__AnonymousType149<T1, T2> Create<T1, T2>(T1 a1, T2 a2)
        => new _003C_003Ef__AnonymousType149<T1, T2>(a1, a2);
}
