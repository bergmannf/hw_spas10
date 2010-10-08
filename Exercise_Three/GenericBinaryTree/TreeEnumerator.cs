using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBinaryTree
{
    class TreeEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private int index = -1;
        private BinaryTree<T> binaryTree;

        public TreeEnumerator(BinaryTree<T> binTree)
        {
            this.binaryTree = binTree;
        }

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current
        {
            get
            {
                if (index > -1)
                {
                    return binaryTree[index];
                }
                else
                {
                    return -1;
                };
            }
        }

        public bool MoveNext()
        {
            this.index++;
            if (index < this.binaryTree.Elements)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this.index = -1;
        }

        #endregion

        T IEnumerator<T>.Current
        {
            get { return binaryTree[index].Value; }
        }

        public void Dispose()
        {
            this.index = -1;
        }
    }
}
