using System;

namespace GenericsHomework
{
    public class PriorityQueue<T>
    {
        private PriorityItem<T>[] _items;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public bool IsEmpty
        {
            get { return _count == 0; }
        }

        public PriorityQueue(int capacity = 10)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            _items = new PriorityItem<T>[capacity];
            _count = 0;
        }

        private void Resize()
        {
            PriorityItem<T>[] newItems = new PriorityItem<T>[_items.Length * 2];
            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        public void Enqueue(T value, int priority)
        {
            if (_count == _items.Length)
            {
                Resize();
            }

            int index = _count - 1;
            while (index >= 0 && _items[index].Priority < priority)
            {
                _items[index + 1] = _items[index];
                index--;
            }

            _items[index + 1] = new PriorityItem<T>(value, priority);
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T result = _items[0].Value;
            for (int i = 0; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = null;
            _count--;
            return result;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _items[0].Value;
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _items[i] = null;
            }
            _count = 0;
        }

        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Priority queue is empty.");
                return;
            }

            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_items[i]);
            }
        }
    }
}