using System;

namespace GenericsHomework
{
    public class CircularQueue<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public int Capacity
        {
            get { return _items.Length; }
        }

        public bool IsEmpty
        {
            get { return _count == 0; }
        }

        public bool IsFull
        {
            get { return _count == _items.Length; }
        }

        public CircularQueue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            _items = new T[capacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Circular queue is full.");
            }

            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Circular queue is empty.");
            }

            T item = _items[_head];
            _items[_head] = default(T);
            _head = (_head + 1) % _items.Length;
            _count--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Circular queue is empty.");
            }

            return _items[_head];
        }

        public void Clear()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = default(T);
            }
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Circular queue is empty.");
                return;
            }

            for (int i = 0; i < _count; i++)
            {
                int index = (_head + i) % _items.Length;
                Console.Write($"{_items[index]} ");
            }
            Console.WriteLine();
        }
    }
}