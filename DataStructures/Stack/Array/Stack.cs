using System;
using System.Collections.Generic;

namespace DataStructures.Stack.Array
{
    public class Stack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Create and array which size will be changed automatically
        /// </summary>
        private T[] _items = new T[0];

        /// <summary>
        /// Here we will keep current number of elements in the array
        /// </summary>
        private int _size;


        public void Push (T item)
        {
            if (_items.Length == _size)
            {
                int newSize = _size == 0 ? 4 : _size*2;
                
                var newArray = new T[newSize];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            _items[_size] = item;
            _size++;
        }

        public T Pop()
        {
            if (_items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            _size--;

            return _items[_size];
        }

        public T Peek()
        {
            if (_items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _items[_size--];
        }


        public void Clear()
        {
            _size = 0;
        }

        public int Count { get { return _items.Length; } }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
