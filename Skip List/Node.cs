using System;
using System.Collections.Generic;
using System.Text;

namespace Skip_List
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value; 
        public Node<T>? Next;
        public Node<T>? Down; 
        public int Height { get; set; }

        public Node(T value)
        {
            Value = value;
            Height = 1;
        }
        public Node(T value, Node<T> down)
        {
            Value = value;
            Down = down;
        }
    }
}
