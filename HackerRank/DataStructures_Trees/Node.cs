using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Trees
{//Binary Search Tree
    public class Node
    {
        private Node left, right;
        private int data;

        public Node(int data)
        {
            this.data = data;
        }

        public void Insert(int value)
        {
            if (value <= data)
            {
                if (left == null)
                    left = new Node(value);
                else
                    left.Insert(value);
            }
            else
            {
                if (right == null)
                    right = new Node(value);
                else
                    right.Insert(value);
            }
        }

        public bool Contains(int value)
        {
            bool result = false;

            if (value == data)
                return true;
            else if (value < data)
            {
                if (left == null)
                    return false;
                else
                    return left.Contains(value);
            }
            else if (value > data)
            {
                if (right == null)
                    return false;
                else
                    return right.Contains(value);
            }

            return result;
        }

        public void PrintInOrder()
        {
            if (left != null)
                left.PrintInOrder();

            Console.WriteLine(data);

            if (right != null)
                right.PrintInOrder();
        }

        //inorder: left,root,right
        //preorder: root,left,right
        //postorder: left,right,root
    }
}
