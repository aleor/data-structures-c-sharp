using System;
using System.Collections.Generic;

namespace DataStructures.Queue.Linked_List
{
    public class Queue<T> : IEnumerable<T>
    {

        private LinkedList<T> _queue = new LinkedList<T>();

        public void Enqueue(T item)
        {
            _queue.AddLast(item);
        }

        public T Dequeue()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T value = _queue.First.Value;
            _queue.RemoveFirst();

            return value;

        }

        public T Peek()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _queue.First.Value;
        }

        public int Count { get { return _queue.Count; } }

        public void Clear()
        {
            _queue.Clear();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }
}
