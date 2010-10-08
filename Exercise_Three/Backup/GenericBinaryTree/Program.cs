using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> intTree = new BinaryTree<int>(new Node<int>(5));
            intTree.Insert(4);
            intTree.Insert(6);
            intTree.Insert(7);
            Console.WriteLine("Tree has {0} elements", intTree.Elements);
            Node<int> n = intTree[2];
            Console.ReadLine();
        }
    }
}
