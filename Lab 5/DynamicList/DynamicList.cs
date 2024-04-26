using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicList
{
    public class DynamicsList<T> : IEnumerable<T>
    {
        private T[] items;

        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public int Count { get; private set; }
        private int _capasity = 0;

        public DynamicsList()
        {
            Count = 0;
            items = [];
        }

        public void Add(T elem)
        {
            if (_capasity == Count)
            {
                _capasity = (int)(_capasity * 1.5f + 1);

                var copy = new T[Count];

                for (int i = 0; i < Count; i++)
                {
                    copy[i] = items[i];
                }

                items = new T[_capasity];
                for (int i = 0; i < Count; i++)
                {
                    items[i] = copy[i];
                }
            }

            items[Count] = elem;
            Count++;
        }

        public int IndexOf(T elem)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(elem))
                {
                    return i;
                }
            }
            return -1;
        }

        //deleting first equals
        public bool Remove(T elem)
        {
            return RemoveAt(IndexOf(elem));
        }

        //at index
        public bool RemoveAt(int index)
        {
            if (index > Count || index < 0)
                return false;
            else
            {
                for (int i = index; i < Count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                Count--;
                return true;
            }
        }

        public void Clear(){
            items = [];
            Count = 0;
            _capasity = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}