using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBinaryTree
{
    class BinaryTree<T> where T : IComparable
    {
        public Node<T> Root { get; private set; }

        public int Elements { get; private set; }

        public BinaryTree()
        { }

        public BinaryTree(Node<T> root)
        {
            this.Root = root;
            this.Elements++;
        }

        public void Insert(T value)
        {
            Insert(value, null);
        }

        /// <summary>
        /// Inserts a node in the tree.
        /// </summary>
        /// <param name="value">New value to be inserted.</param>
        /// <param name="node">The current node an insertion should take place.</param>
        private void Insert(T value, Node<T> node)
        {
            if (Root == null)
            {
                this.Elements++;
                this.Root = new Node<T>(value);
            }
            else if (node == null)
            {
                this.Insert(value, Root);
            }
            else
            {
                if (node.Value.CompareTo(value) < 0)
                {
                    if (node.LeftChild == null)
                    {
                        this.Elements++;
                        node.LeftChild = new Node<T>(value);
                    }
                    else
                    {
                        Insert(value, node.LeftChild);
                    }
                }
                else if (node.Value.CompareTo(value) > 1)
                {
                    if (node.RightChild == null)
                    {
                        this.Elements++;
                        node.RightChild = new Node<T>(value);
                    }
                    else
                    {
                        Insert(value, node.RightChild);
                    }
                }
            }
        }

        public Node<T> this[int index]
        {
            get
            {
                if (index > this.Elements)
                {
                    throw new IndexOutOfRangeException("There are not enough nodes in the tree.");
                }
                else
                {
                    return this.Traverse(Root, index);
                }
            }
        }

        private Node<T> Traverse(Node<T> node, int depth)
        {
            if (depth == 0)
            {
                return node;
            }
            else
            {
                if (node.LeftChild != null)
                {
                    return Traverse(node.LeftChild, --depth);
                }
                else if (node.RightChild != null)
                {
                    return Traverse(node.RightChild, --depth);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
