using System;

public class Deque<T>
{
    private T[] array;
    private int front;
    private int rear;
    private int capacity;
    private int count;

    public Deque(int size)
    {
        array = new T[size];
        capacity = size;
        front = 0;
        rear = -1;
        count = 0;
    }

    public void AddFront(T item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Deque is full");
        }

        front = (front - 1 + capacity) % capacity;
        array[front] = item;
        count++;
    }

    public void AddRear(T item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Deque is full");
        }

        rear = (rear + 1) % capacity;
        array[rear] = item;
        count++;
    }

    public T RemoveFront()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T removedItem = array[front];
        front = (front + 1) % capacity;
        count--;
        return removedItem;
    }

    public T RemoveRear()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T removedItem = array[rear];
        rear = (rear - 1 + capacity) % capacity;
        count--;
        return removedItem;
    }

    public T PeekFront()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }

        return array[front];
    }

    public T PeekRear()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }

        return array[rear];
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == capacity;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Deque<int> deque = new Deque<int>(5);
        deque.AddRear(10);
        deque.AddRear(20);
        deque.AddFront(5);
        deque.AddFront(2);

        Console.WriteLine("Front element: " + deque.PeekFront());
        Console.WriteLine("Rear element: " + deque.PeekRear());

        Console.WriteLine("Removing front element: " + deque.RemoveFront());
        Console.WriteLine("Removing rear element: " + deque.RemoveRear());

        Console.WriteLine("Front element after removal: " + deque.PeekFront());
        Console.WriteLine("Rear element after removal: " + deque.PeekRear());
    }
}