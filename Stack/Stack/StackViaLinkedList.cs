using System;
using System.Collections;
using System.Collections.Generic;

namespace CRiUPP_lab_01
{
    public class StackViaLinkedList<T> : IStack<T>, IEnumerable<T>, ICloneable
    {
        LinkedList<T> _collection;

        public int Count
        {
            get => _collection.Count;
        }
        public StackViaLinkedList()
        {
            _collection = new LinkedList<T>();
        }
        public StackViaLinkedList(ICollection<T> collection) : this()
        {
            foreach (var t in collection)
            {
                _collection.AddLast(t);
            }
        }

        public void Push(T item)
        {
            _collection.AddLast(item);
        }

        public T Peek()
        {
            T result;
            try
            {
                result = _collection.Last.Value;
            }
            catch (System.Exception ex)
            {
                throw new System.NullReferenceException(ex.Message, ex);
            }
            return result;
        }

        public T Pop()
        {
            T result;
            try
            {
                result = _collection.Last.Value;
                _collection.RemoveLast();
            }
            catch (System.Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message, ex);
            }
            return result;
        }

        public void Clear() => _collection.Clear();

        public bool Contains(T item) => _collection.Contains(item);

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        public StackViaLinkedListEnum<T> GetEnumerator()
        {
            return new StackViaLinkedListEnum<T>(_collection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        public object Clone()
        {
            return new StackViaLinkedList<T>(_collection);
        }
    }
}
