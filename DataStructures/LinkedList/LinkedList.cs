
using System.Collections;
using System.Collections.Generic;


namespace DataStructures.LinkedList
{
    /// <summary>
    /// A linked list collection capable to perform simple operations
    /// such as Add, Remove, Find and Enumerate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> :ICollection<T>
    {
        /// <summary>
        /// A first node in the list or null if empty
        /// </summary>
        public LinkedListNode<T> Head { get; private set; }

        /// <summary>
        /// Last node in the list or null if empty
        /// </summary>
        public LinkedListNode<T> Tail { get; private set; }

        #region Add
        /// <summary>
        /// Adds the specified value to the start of the list
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// Adds the specified node to the start of the list
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(LinkedListNode<T> node)
        {
            
            //Save off the Head node so we don't lose it
            LinkedListNode<T> temp = Head;

            //Point Head to new node
            Head = node;

            //Insert the rest of the list behind the Head
            Head.Next = temp;

            Count++;

            //if there is only one element, head should point to tail
            if (Count == 1)
            {
                Head = Tail;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;

            Count++;

        }
        #endregion

        #region Remove

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;
            }

            if (Count == 0)
            {
                Tail = null;
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    LinkedListNode<T> current = Head;
                    while (current.Next != Tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Tail = current;
                }
                Count--;
            }
        }
        #endregion

        #region ICollection

        public int Count { get; private set; }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Removes first occurence in the list, going from Head to Tail
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <returns>True if item was found and removed, false otherwise</returns>
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            // 4 cases are possible:
            // 1. Empty list - do nothing;
            // 2. List with one item (and it should be removed) - previous is null
            // 3. Many nodes in the list:
            //  a. Node to remove is a first node;
            //  b. Node to remove is in the middle or the last node

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // if the node in the middle or in the end
                    if (previous != null)
                    {
                        //Case 3b
                        previous.Next = current.Next;

                        //if it was the end -> update Tail
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        //Case 2 or 3a 
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Enumerates through the list from Head to Tail
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        } 

        #endregion

    }
}
