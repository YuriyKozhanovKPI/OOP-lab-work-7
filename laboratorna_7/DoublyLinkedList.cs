using System;
using System.Collections;

namespace DoublyLinkedListApp
{
    public class Node
    {
        public double Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(double data)
        {
            Data = data;
        }
    }

    public class CustomDoublyLinkedList : IEnumerable<double>
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Count { get; private set; }

        public void AddFirst(double data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }
            Count++;
        }

        public void Remove(Node node)
        {
            if (node == null) return;

            if (node.Prev != null)
                node.Prev.Next = node.Next;
            else
                Head = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;
            else
                Tail = node.Prev;

            Count--;
        }

        public void Print()
        {
            if (Head == null)
            {
                Console.WriteLine("Список порожній");
                return;
            }

            Node current = Head;
            while (current != null)
            {
                Console.Write($"{current.Data} ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public IEnumerator<double> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}