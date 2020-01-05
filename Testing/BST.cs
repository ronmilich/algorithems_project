using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class BST<T> where T : IComparable<T>
    {
        Node root;

        public T Add(T val)
        {
            Node newNode = new Node(val);
            if (root == null)
            {
                root = newNode;
                return root.info;
            }

            Node tmp = root;
            Node parent = null;
            while (tmp != null)
            {
                parent = tmp;
                if (val.CompareTo(tmp.info) == 0)
                    return tmp.info;
                else if (val.CompareTo(tmp.info) < 0)
                    tmp = tmp.left;
                else
                    tmp = tmp.right;

            }
            if (val.CompareTo(parent.info) < 0)
            {
                parent.left = newNode;
                return parent.left.info;
            }
            else
            {
                parent.right = newNode;
                return parent.right.info;
            }
                
        }

        public void Remove(T val) => Remove(val, root);

        private Node Remove(T val, Node root)
        {
            if (root == null) return root;

            if (val.CompareTo(root.info) < 0)
                root.left = Remove(val, root.left);
            else if (val.CompareTo(root.info) > 0)
                root.right = Remove(val, root.right);
            else
            {
                // case when the node is the root
                if (this.root == root && root.left == null && root.right == null)
                {
                    this.root = null;
                }
                else if (this.root == root && root.left != null && root.right == null)
                {
                    this.root = root.left;
                    return this.root;
                }
                else if (this.root == root && root.left == null && root.right != null)
                {
                    this.root = root.right;
                    return this.root;
                }

                // case when 
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;
                
                root.info = MinValue(root.right);
                root.right = Remove(root.info, root.right);
            }

            return root;
        }

        private T MinValue(Node root)
        {
            T min = root.info;
            while (root.left != null)
            {
                min = root.left.info;
                root = root.left;
            }
            return min;
        }

        public void PrintInOrder(Action<T> action)
        {
            PrintInOrder(root, action);
        }

        private void PrintInOrder(Node currentRoot, Action<T> action)
        {
            if (currentRoot == null)
                return ;
            PrintInOrder(currentRoot.left, action);
            action(currentRoot.info);
            Console.Write(" ");
            PrintInOrder(currentRoot.right, action);
        }

        public object Find(T val)
        {
            if (root == null)
                return default(T);

            Node tmp = root;
            Node parent = null;
            while (tmp != null)
            {
                parent = tmp;
                if (val.CompareTo(tmp.info) == 0)
                    return tmp.info;
                else if (val.CompareTo(tmp.info) < 0) //val < tmp.info
                    tmp = tmp.left;
                else
                    tmp = tmp.right;

            }
            if (val.CompareTo(parent.info) < 0)
            {
                if (parent.left == null)
                {
                    return null;
                }
                else
                {
                   return parent.left.info;
                }
            }
            else
            {
                if (parent.right == null)
                {
                    return null;
                }
                else
                {
                    return parent.right.info;
                }
            }
        }

        public int CountLevels() => CountLevels(root);

        private int CountLevels(Node currentRoot)
        {
            if (currentRoot == null)
                return 0;
            int leftlevels = CountLevels(currentRoot.left);

            int rightlevels = CountLevels(currentRoot.right);

            return Math.Max(rightlevels, leftlevels) + 1;
        }

        //private void FindClosest(Node root, double value, ref double minimumDistance, ref T closestBox)
        //{
        //    if (root == null) return;

        //    double rootValue = double.Parse(root.info.ToString());
 
        //    if (rootValue == value)
        //    {
        //        closestBox = root.info;
        //        return;
        //    }

        //    if (minimumDistance > Math.Abs(rootValue - value))
        //    {
        //        minimumDistance = Math.Abs(rootValue - value);
        //        closestBox = root.info;
        //    }

        //    if (value < rootValue)
        //    {
        //        FindClosest(root.left, value, ref minimumDistance, ref closestBox);
        //    }
        //    else
        //    {
        //        FindClosest(root.right, value, ref minimumDistance, ref closestBox);
        //    }
        //}

        //public T FindClosest(double value)
        //{
        //    double minimumDistance = int.MaxValue;
        //    T closestBox = root.info;

        //    FindClosest(root, value, ref minimumDistance, ref closestBox);
        //    return closestBox;
        //}

        private void FindClosest(Node root, T value, ref T savedValue)
        {
            
            if (root == null)
            {
                return;
            }

            if (root.info.Equals(value))
            {
                savedValue = root.info;
            }

            if (value.CompareTo(root.info) > 0)
            {
                FindClosest(root.right, value, ref savedValue);
            }
            else
            {
                savedValue = root.info;
                FindClosest(root.left, value, ref savedValue);
            }
        }

        public T FindClosest(T value)
        {
            T savedValue = root.info;
            FindClosest(root, value, ref savedValue);

            return savedValue;
        }

        public class Node
        {
            public T info;
            public Node left;
            public Node right;

            public Node(T info)
            {
                this.info = info;
            }
        }
    }
}
