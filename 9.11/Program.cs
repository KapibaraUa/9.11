using System;

namespace GenericsHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Task 1: Swap ===");
                int a = 10;
                int b = 25;
                Console.WriteLine($"Before: a = {a}, b = {b}");
                SwapHelper.Swap(ref a, ref b);
                Console.WriteLine($"After: a = {a}, b = {b}");

                string firstWord = "Hello";
                string secondWord = "World";
                Console.WriteLine($"Before: {firstWord}, {secondWord}");
                SwapHelper.Swap(ref firstWord, ref secondWord);
                Console.WriteLine($"After: {firstWord}, {secondWord}");

                Console.WriteLine("\n=== Task 2: PriorityQueue ===");
                PriorityQueue<string> priorityQueue = new PriorityQueue<string>(3);
                priorityQueue.Enqueue("Low task", 1);
                priorityQueue.Enqueue("Critical task", 5);
                priorityQueue.Enqueue("Normal task", 3);
                priorityQueue.Enqueue("Urgent task", 5);
                priorityQueue.Print();
                Console.WriteLine($"Peek: {priorityQueue.Peek()}");
                Console.WriteLine($"Dequeue: {priorityQueue.Dequeue()}");
                Console.WriteLine($"Count: {priorityQueue.Count}");
                priorityQueue.Print();

                Console.WriteLine("\n=== Task 3: CircularQueue ===");
                CircularQueue<int> circularQueue = new CircularQueue<int>(3);
                circularQueue.Enqueue(10);
                circularQueue.Enqueue(20);
                circularQueue.Enqueue(30);
                circularQueue.Print();
                Console.WriteLine($"Dequeue: {circularQueue.Dequeue()}");
                circularQueue.Enqueue(40);
                circularQueue.Print();
                Console.WriteLine($"Peek: {circularQueue.Peek()}, IsFull: {circularQueue.IsFull}");

                Console.WriteLine("\n=== Task 4: SinglyLinkedList ===");
                SinglyLinkedList<string> singlyList = new SinglyLinkedList<string>();
                singlyList.AddLast("First");
                singlyList.AddLast("Second");
                singlyList.AddFirst("Zero");
                singlyList.Print();
                Console.WriteLine($"Contains Second: {singlyList.Contains("Second")}");
                singlyList.Remove("Second");
                singlyList.Print();
                Console.WriteLine($"Removed first: {singlyList.RemoveFirst()}");
                singlyList.Print();

                Console.WriteLine("\n=== Task 5: DoublyLinkedList ===");
                DoublyLinkedList<int> doublyList = new DoublyLinkedList<int>();
                doublyList.AddLast(100);
                doublyList.AddLast(200);
                doublyList.AddFirst(50);
                doublyList.AddLast(300);
                doublyList.PrintForward();
                doublyList.PrintBackward();
                doublyList.Remove(200);
                doublyList.RemoveLast();
                doublyList.PrintForward();
                Console.WriteLine($"Count: {doublyList.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}