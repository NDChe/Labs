using System;
using System.Threading;

namespace BinaryTree
{
    class Program
    {
        public static int sum = 0; public static int count = 0;
        public class TreeNode
        {           
            private Node _root;

            public Node Root { get => _root; set => _root = value; }

            public Node AddNode(int inputDataNode, Node root, Node Parent)
            {
                if (root == null)
                {
                    root = new Node(inputDataNode);
                    root.Parent = Parent;
                }
                else
                {
                    if (inputDataNode < root.Data)
                    {
                        root.Left = AddNode(inputDataNode, root.Left, root);
                    }
                    else
                    {
                        root.Right = AddNode(inputDataNode, root.Right, root);
                    }
                }

                return root;
            }

            public Node FindElement(int findData, Node root)
            {
                if (root == null || findData == root.Data)
                    return root;
                else if (root.Data < findData)
                    return FindElement(findData, root.Left);
                else
                    return FindElement(findData, root.Right);
            }

            public Node Minimum(Node root)
            {
                if (root != null)
                {
                    if (root.Left != null) root = Minimum(root.Left);
                }
                return root;
            }

            public Node DeleteNode(int deleteData, Node root)
            {
                if (root == null)
                    return root;
                if (deleteData < root.Data)
                {
                    root.Left = DeleteNode(deleteData, root.Left);
                }
                else if (deleteData > root.Data)
                {
                    root.Right = DeleteNode(deleteData, root.Right);
                }
                else if (root.Left != null && root.Right != null)
                {
                    root.Data = Minimum(root.Right).Data;
                    root.Right = DeleteNode(root.Data, root.Right);
                }
                else if (root.Left != null)
                {
                    return root.Left;
                }
                else
                {
                    return root.Right;
                }

                return root;

            }

            public void PrintTree(int x, int y, Node root, int delta = 0)
            {
                if (root != null)
                {
                    if (delta == 0) delta = x / 2;
                    Console.SetCursorPosition(x, y);
                    Console.Write(root.Data);
                    PrintTree(x - delta, y + 3, root.Left, delta / 2);
                    PrintTree(x + delta, y + 3, root.Right, delta / 2);
                }

            }

            public void ClearTree()
            {
                _root = null;
            }

            public void CountElements(object node, ref int count)
            {
                Node root = (Node)node;
                if (root != null)
                {
                    count++;
                    CountElements(root.Left, ref count);
                    CountElements(root.Right, ref count);
                }
            }

            public void SummaElements(object node, ref int sum)
            {
                Node root = (Node)node;
                if (root != null)
                {
                    sum+=root.Data;
                    SummaElements(root.Left, ref sum);
                    SummaElements(root.Right, ref sum);
                }
            }

            public bool IsEmpty()
            {
                return _root == null ? true : false;
            }

        }

        public class Node
        {
            private int _data;
            private Node _left;
            private Node _right;
            private Node _parent;

            public Node()
            {
            }

            public Node(int inputDataNode)
            {
                Data = inputDataNode;
            }

            public Node(int data, Node left, Node right)
            {
                Data = data;
                Left = left;
                Right = right;
            }

            public int Data { get => _data; set => _data = value; }
            public Node Left { get => _left; set => _left = value; }
            public Node Right { get => _right; set => _right = value; }
            public Node Parent { get => _parent; set => _parent = value; }
        }

        

        static void Main(string[] args)
        {
            TreeNode tree = new TreeNode();
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 7; i++)
            {
                tree.Root = tree.AddNode(random.Next(0, 10), tree.Root, null);
            }
            tree.PrintTree(Console.WindowWidth / 2, 0, tree.Root);

            int sum = 0;
            int count = 0;
            Console.SetCursorPosition(0, 25);
            object TRoot = tree.Root;
            Thread thread_1 = new Thread(() => { tree.SummaElements(tree.Root, ref sum); });
            Thread thread_2 = new Thread(() => { tree.CountElements(tree.Root, ref count); });
            thread_1.Start();
            thread_2.Start();
            Thread.Sleep(100);
            Console.WriteLine(sum);
            Console.WriteLine(count);
            Console.WriteLine(sum / count);
            Console.ReadKey();
        }
    }
}
