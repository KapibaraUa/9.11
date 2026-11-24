using System;

namespace GenericsHomework
{
    public class PriorityItem<T>
    {
        public T Value { get; set; }
        public int Priority { get; set; }

        public PriorityItem(T value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{Value} (priority: {Priority})";
        }
    }
}