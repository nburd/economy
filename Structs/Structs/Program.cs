using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs
{
    class Program
    {
        class Node
        {
            public Node Next { get; set; }

            public int Value { get; set; }

            public Node(Node next, int value)
            {
                Next = next;
                Value = value;
            }
        }

        class LinkList
        {
            private Node head = null;
            private Node tail = null;

            public LinkList() { }

            public void Add(int value)
            {
                Node element = new Node(null, value);
                if (head == null)
                    head = tail = element;
                else
                {
                    tail.Next = element;
                    tail = element;
                }
            }

            public void Print()
            {
                Node list = head;
                while (list != null)
                {
                    Console.WriteLine(list.Value);
                    list = list.Next;
                }
            }

        }

        class Stack
        {
            private Node head = null;
            private Node tail = null;

            public Stack() { }

            public void Add(int value)
            {
                Node element = new Node(null, value);
                if (head == null)
                {
                    head = tail = element;
                }
                else
                {
                    element.Next = head;
                    head = element;
                }
            }

            public void Print()
            {
                Node list = head;
                while (list != null)
                {
                    Console.WriteLine(list.Value);
                    list = list.Next;
                }
            }
        }

        static void Main(string[] args)
        {
            Stack mylist = new Stack();
            for (int i = 0; i < 6; i++)
                mylist.Add(i);
            mylist.Print();
            Console.ReadKey();
        }
    }
}
