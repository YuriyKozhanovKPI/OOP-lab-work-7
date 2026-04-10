using System;

namespace DoublyLinkedListApp
{
    public class TaskSolver
    {
        private CustomDoublyLinkedList _list;

        public TaskSolver(CustomDoublyLinkedList list)
        {
            _list = list ?? throw new ArgumentNullException(nameof(list));
        }

        public (double Value, int Index)? FindFirstLessThanAverage()
        {
            if (_list.Count == 0) return null;

            double average = _list.Average();
            int index = 0;

            foreach (var item in _list)
            {
                if (item < average)
                {
                    return (item, index);
                }
                index++;
            }
            return null;
        }

        public double SumAfterMax()
        {
            if (_list.Head == null || _list.Head.Next == null) return 0;

            Node maxNode = _list.Head;
            Node current = _list.Head.Next;

            while (current != null)
            {
                if (current.Data > maxNode.Data)
                {
                    maxNode = current;
                }
                current = current.Next;
            }

            double sum = 0;
            current = maxNode.Next;

            while (current != null)
            {
                sum += current.Data;
                current = current.Next;
            }

            return sum;
        }

        public CustomDoublyLinkedList GetListGreaterThan(double threshold)
        {
            var newList = new CustomDoublyLinkedList();

            Node current = _list.Tail;
            while (current != null)
            {
                if (current.Data > threshold)
                {
                    newList.AddFirst(current.Data);
                }
                current = current.Prev;
            }

            return newList;
        }

        public void RemoveBeforeMax()
        {
            if (_list.Head == null) return;

            Node maxNode = _list.Head;
            Node current = _list.Head.Next;

            while (current != null)
            {
                if (current.Data > maxNode.Data)
                {
                    maxNode = current;
                }
                current = current.Next;
            }

            Node toRemove = _list.Head;
            while (toRemove != null && toRemove != maxNode)
            {
                Node nextNode = toRemove.Next;
                _list.Remove(toRemove);
                toRemove = nextNode;
            }
        }
    }
}