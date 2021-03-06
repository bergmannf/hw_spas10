﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBinaryTree
{
    class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        public Node<T> Root { get; private set; }

        public int Elements { get; private set; }

        public delegate T Transform(T element);

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
                if (node.Value.CompareTo(value) >= 1)
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
                else if (node.Value.CompareTo(value) < 0)
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
                    return this.Traverse(index);
                }
            }
        }

        private IEnumerable<Node<T>> Traverse()
        {
            List<Node<T>> elements = new List<Node<T>>();
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(Root);
            Node<T> currentNode = null;
            while (!(stack.Count == 0))
            {
                currentNode = stack.Pop();
                Node<T> left = currentNode.LeftChild;
                Node<T> right = currentNode.RightChild;
                if (right != null)
                {
                    stack.Push(right);
                }
                if (left != null)
                {
                    stack.Push(left);
                }
                elements.Add(currentNode);
            }
            return elements;
        }

        private Node<T> Traverse(int depth)
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(Root);
            Node<T> currentNode = null;
            while (!(stack.Count == 0))
            {
                currentNode = stack.Pop();
                if (depth == 0)
                {
                    break;
                }
                else
                {
                    Node<T> left = currentNode.LeftChild;
                    Node<T> right = currentNode.RightChild;
                    if (right != null)
                    {
                        stack.Push(right);
                    }
                    if (left != null)
                    {
                        stack.Push(left);
                    }
                }
                --depth;
            }
            return currentNode;
        }

        public void Collect(Transform t)
        {
            IEnumerable<Node<T>> elements = this.Traverse();
            foreach (Node<T> elem in elements)
            {
                elem.Value = t(elem.Value);
            }
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return new TreeEnumerator<T>(this);
        }

        #endregion

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new TreeEnumerator<T>(this);
        }
    }
}
