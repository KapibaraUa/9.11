using System;

namespace GenericsHomework
{
    public class SinglyLinkedList<T>
    {
        private SinglyNode<T> _head;
        private SinglyNode<T> _tail;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public bool IsEmpty
        {
            get { return _count == 0; }
        }

        public SinglyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void AddFirst(T data)
        {
            SinglyNode<T> node = new SinglyNode<T>(data);
            node.Next = _head;
            _head = node;

            if (_count == 0)
            {
                _tail = node;
            }

            _count++;
        }

        public void AddLast(T data)
        {
            SinglyNode<T> node = new SinglyNode<T>(data);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            _count++;
        }

        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }

            T data = _head.Data;
            _head = _head.Next;
            _count--;

            if (_count == 0)
            {
                _tail = null;
            }

            return data;
        }

        public T RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }

            if (_head == _tail)
            {
                T data = _head.Data;
                _head = null;
                _tail = null;
                _count = 0;
                return data;
            }

            SinglyNode<T> current = _head;
            while (current.Next != _tail)
            {
                current = current.Next;
            }

            T removedData = _tail.Data;
            _tail = current;
            _tail.Next = null;
            _count--;
            return removedData;
        }

        public bool Remove(T data)
        {
            SinglyNode<T> current = _head;
            SinglyNode<T> previous = null;

            while (current != null)
            {
                if (object.Equals(current.Data, data))
                {
                    if (previous == null)
                    {
                        _head = current.Next;
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T data)
        {
            SinglyNode<T> current = _head;
            while (current != null)
            {
                if (object.Equals(current.Data, data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Singly linked list is empty.");
                return;
            }

            SinglyNode<T> current = _head;
            while (current != null)
            {
                Console.Write($"{current.Data} -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }
}