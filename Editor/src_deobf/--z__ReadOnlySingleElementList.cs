using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[CompilerGenerated]
internal sealed class _003C_003Ez__ReadOnlySingleElementList<T> : IEnumerable<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection<T>, IList<T>, IEnumerable, ICollection, IList
{
	private sealed class Class18 : IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly T gparam_0;

		private bool bool_0;

		object IEnumerator.Current => gparam_0;

		T IEnumerator<T>.Current => gparam_0;

		public Class18(T gparam_1)
		{
			gparam_0 = gparam_1;
		}

		bool IEnumerator.MoveNext()
		{
			if (!bool_0)
			{
				bool_0 = true;
				return true;
			}
			return false;
		}

		void IEnumerator.Reset()
		{
			bool_0 = false;
		}

		void IDisposable.Dispose()
		{
		}
	}

	private readonly T gparam_0;

	int ICollection.Count => 1;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	object IList.this[int index]
	{
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return gparam_0;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	bool IList.IsFixedSize => true;

	bool IList.IsReadOnly => true;

	int IReadOnlyCollection<T>.Count => 1;

	T IReadOnlyList<T>.this[int index]
	{
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return gparam_0;
		}
	}

	int ICollection<T>.Count => 1;

	bool ICollection<T>.IsReadOnly => true;

	T IList<T>.this[int index]
	{
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return gparam_0;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public _003C_003Ez__ReadOnlySingleElementList(T item)
	{
		gparam_0 = item;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Class18(gparam_0);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		array.SetValue(gparam_0, index);
	}

	int IList.Add(object value)
	{
		throw new NotSupportedException();
	}

	void IList.Clear()
	{
		throw new NotSupportedException();
	}

	bool IList.Contains(object value)
	{
		return EqualityComparer<T>.Default.Equals(gparam_0, (T)value);
	}

	int IList.IndexOf(object value)
	{
		if (!EqualityComparer<T>.Default.Equals(gparam_0, (T)value))
		{
			return -1;
		}
		return 0;
	}

	void IList.Insert(int index, object value)
	{
		throw new NotSupportedException();
	}

	void IList.Remove(object value)
	{
		throw new NotSupportedException();
	}

	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return new Class18(gparam_0);
	}

	void ICollection<T>.Add(T item)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<T>.Contains(T item)
	{
		return EqualityComparer<T>.Default.Equals(gparam_0, item);
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		array[arrayIndex] = gparam_0;
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	int IList<T>.IndexOf(T item)
	{
		if (!EqualityComparer<T>.Default.Equals(gparam_0, item))
		{
			return -1;
		}
		return 0;
	}

	void IList<T>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	void IList<T>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}
}
