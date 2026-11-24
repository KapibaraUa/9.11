using System;

namespace GenericsHomework
{
    public class DoublyLinkedList<T>
    {
        private DoublyNode<T> _head;
        private DoublyNode<T> _tail;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public bool IsEmpty
        {
            get { return _count == 0; }
        }

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                node.Next = _head;
                _head.Previous = node;
                _head = node;
            }

            _count++;
        }

        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (_tail == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
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

            if (_head != null)
            {
                _head.Previous = null;
            }
            else
            {
                _tail = null;
            }

            _count--;
            return data;
        }

        public T RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }

            T data = _tail.Data;
            _tail = _tail.Previous;

            if (_tail != null)
            {
                _tail.Next = null;
            }
            else
            {
                _head = null;
            }

            _count--;
            return data;
        }

        public bool Remove(T data)
        {
            DoublyNode<T> current = _head;

            while (current != null)
            {
                if (object.Equals(current.Data, data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        _head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        _tail = current.Previous;
                    }

                    _count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = _head;
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

        public void PrintForward()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Doubly linked list is empty.");
                return;
            }

            DoublyNode<T> current = _head;
            while (current != null)
            {
                Console.Write($"{current.Data} <-> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        public void PrintBackward()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Doubly linked list is empty.");
                return;
            }

            DoublyNode<T> current = _tail;
            while (current != null)
            {
                Console.Write($"{current.Data} <-> ");
                current = current.Previous;
            }
            Console.WriteLine("null");
        }
    }
}