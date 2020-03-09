using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWithRangeSums
{
    class Program
    {
        public static Node root;
        static void Main(string[] args)
        {
            STInsert(root, 4);
            STInsert(root, 5);
            STInsert(root, 6);
            STInsert(root, 1);
            STInsert(root, 2);
            STInsert(root, 3);
            
            Print(root);
            Console.WriteLine();
            Console.ReadLine();
        }

        public class Node
        {
            public Node left;
            public Node right;
            public Node parent;
            public int? key;

            public Node()
            {
                this.left = null;
                this.right = null;
                this.parent = null;
                this.key = null;
            }

            public Node(int key)
            {
                this.left = null;
                this.right = null;
                this.parent = null;
                this.key = key;
            }
        }

        public static Node Find(Node v, int key)
        {
            if (v == null)
                return null;
            else if (v.key == key)
                return v;
            else if (v.key < key && v.right != null)
                return Find(v.right, key);
            else if (v.key > key && v.left != null)
                return Find(v.left, key);
            else
                return v;
        }

        public static Node STFind(int key)
        {
            Node N = Find(root, key);
            Splay(N);
            return N;
        }

        public static void Insert(int key)
        {
            Node newNode = new Node(key);

            if (root == null)
            {
                root = newNode;
            }
            else 
            {
                Node v = Find(root, key);

                if(v.key < key)
                {
                    v.right = newNode;
                    newNode.parent = v;
                }
                else if(v.key > key)
                {
                    v.left = newNode;
                    newNode.parent = v; 
                }
            }
        }

        public static void STInsert(Node root, int key)
        {
            Insert(key);
            root = STFind(key);
        }

        public static void Rotate(Node parent, Node child)
        {
            Node gParent = parent.parent;

            if(gParent != null)
            {
                if (gParent.left == parent)
                    gParent.left = child;
                else
                    gParent.right = child;
            }
            
            if(parent.left == child)
            {
                parent.left = child.right;
                child.right = parent;
            }
            else
            {
                parent.right = child.left;
                child.left = parent;
            }

            child.parent = gParent;
            parent.parent = child;
            
        }

        public static Node Splay(Node v)
        {
            if (v == null)
                return null;

            if (v.parent == null)
            {
                root = v;
                return v;
            }

            Node parent = v.parent;
            Node gParent = parent.parent;

            if(gParent == null)
            {
                Rotate(parent, v);
                root = v;
                return v;
            }
            else
            {
                bool zigzig = (gParent.left == parent && parent.left == v) || (gParent.right == parent && parent.right == v);

                if(zigzig)
                {
                    Rotate(gParent, parent);
                    Rotate(parent, v);
                }
                else
                {
                    Rotate(parent, v);
                    Rotate(gParent, v);
                }

                return Splay(v);
            }
        }

        //public static void Insert(int key)
        //{
        //    Tuple<Node, Node> s = Split(key);

        //    Node newNode = new Node();
        //    newNode.key = key;
        //    newNode.left = s.Item1;
        //    newNode.right = s.Item2;

        //    if (s.Item1 != null)
        //        s.Item1.parent = newNode;

        //    if (s.Item2 != null)
        //        s.Item2.parent = newNode;
        //}

        //public static Tuple<Node, Node> Split(int key)
        //{
        //    Node v = Find(root, key);

        //    Splay(v);

        //    if(v.key == key)
        //    {
        //        if (v.left != null)
        //            v.left.parent = null;
        //        if (v.right != null)
        //            v.right.parent = null;

        //        return new Tuple<Node, Node>(v.left, v.right);
        //    }
        //    else if(v.key < key)
        //    {
        //        Node right = v.right;
        //        right.parent = null;
        //        v.right = null;
        //        return new Tuple<Node, Node>(v, right);
        //    }
        //    else
        //    {
        //        Node left = v.left;
        //        left.parent = null;
        //        v.left = null;
        //        return new Tuple<Node, Node>(left, v);
        //    }
        //}

        public static void Print(Node v)
        {
            if (v == null)
                return; 

            if(v != null)
            {
                Console.Write(v.key + " ");
                Print(v.left);
                Print(v.right);
            }
        }
    }
}
