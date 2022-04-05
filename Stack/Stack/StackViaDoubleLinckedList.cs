using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRiUPP_lab_01
{
    public class StackViaDoubleLinkedList<T> : IStack<T>, IEnumerable<T>, ICloneable
    {
        LinkedList<T> _collection;

        public int Count
        {
            get => _collection.Count;
        }
        public StackViaDoubleLinkedList()
        {
            _collection = new LinkedList<T>();
        }
        public StackViaDoubleLinkedList(ICollection<T> collection) : this()
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

        public StackViaDoubleLinkedListEnum<T> GetEnumerator()
        {
            return new StackViaDoubleLinkedListEnum<T>(_collection);
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

