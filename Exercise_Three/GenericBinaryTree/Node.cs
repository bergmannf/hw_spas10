using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBinaryTree
{
    class Node<T> where T:IComparable
    {
        public T Value { get; private set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
