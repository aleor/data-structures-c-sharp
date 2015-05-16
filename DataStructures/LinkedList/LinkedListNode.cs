﻿namespace DataStructures.LinkedList
{
    public class LinkedListNode<T>
    {
        /// <summary>
        /// Constructs a new node with a specified value
        /// </summary>
        /// <param name="value"></param>
        public LinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Pointer to the next node in the LinkedList
        /// </summary>
        public LinkedListNode<T> Next { get; set; }

    }
}
