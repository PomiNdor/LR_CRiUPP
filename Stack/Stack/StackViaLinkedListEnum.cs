using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRiUPP_lab_01
{
    public class StackViaLinkedListEnum<T> : IEnumerator<T>
    {
        LinkedList<T> _collection;
        int position = -1;

        public StackViaLinkedListEnum(LinkedList<T> _collection)
        {
            this._collection = _collection;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _collection.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    var item = _collection.First;
                    for (int i = 0; i < position; i++)
                    {
                        item = item.Next;
                    }
                    return item.Value;
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose() { }

    }
}
