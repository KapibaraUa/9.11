using System;

namespace GenericsHomework
{
    public class SinglyNode<T>
    {
        public T Data { get; set; }
        public SinglyNode<T> Next { get; set; }

        public SinglyNode(T data)
        {
            Data = data;
            Next = null;
        }
    }
}