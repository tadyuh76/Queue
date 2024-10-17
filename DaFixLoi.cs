/*public class Node
{
    public Node next;
    public object data;
}
public class MyStack
{
    public Node top;

    public bool IsEmpty()
    {
        return top == null;
    }
    public void Push(object ele)
    {
        Node n = new Node();
        n.data = ele;
        n.next = top;
        top = n;
    }
    public Node Pop()
    {
        if (top == null)
            return null;
        Node n = top;
        top = top.next;
        return n;
    }

    public void RemoveOdd()
    {
        MyStack tempStack = new MyStack();
        while (!IsEmpty())
        {
            Node current = Pop();
            if (((int)current.data) % 2 == 0)
            {
                tempStack.Push(current.data);
            }
        }
        while (!tempStack.IsEmpty())
        {
            Push(tempStack.Pop().data);
        }
    }

    public MyStack Sort()
    {
        MyStack TempStack = new MyStack();
        List<int> list = new List<int>();
        while (!IsEmpty())
            list.Add((int)Pop().data);

        foreach (int i in list)
            Push(i);

        Array a = list.ToArray();
        Array.Sort(a);

        foreach (int i in a)
            TempStack.Push(i);
        return TempStack;
    }
}*/

public class Node2
{
    public Node2 prev, next;
    public object data;

    public Node2(object data)
    {
        this.data = data;
    }
}

public class MyQueue
{
    Node2 rear, front;
    public bool IsEmpty()
    {
        return rear == null || front == null;
    }

    public Node2 Dequeue()
    {
        if (front == null) return null;

        Node2 d = front;
        front = front.prev;

        if (front == null)
        {
            rear = null;
        }
        else
        {
            front.next = null;
        }
        return d;
    }

    public void Enqueue(object ele)
    {
        Node2 n = new Node2(ele);
        if (rear == null)
        {
            rear = n; front = n;
        }
        else
        {
            List<int> list = new List<int>();
            while (!IsEmpty())
            {
                list.Add((int)Dequeue().data);
            }
            list.Add((int)ele);
            list.Sort();

            Node2 firstNode = new Node2(list[0]);
            rear = firstNode; front = firstNode;

            for (int i = 1; i < list.Count; i++)
            {
                Node2 n2 = new Node2(list[i]);
                rear.prev = n2;
                n2.next = rear;
                rear = n2;
            }
        }
    }
}

public class Program
{
    public static void Main(String[] args)
    {
        /*MyStack st = new MyStack();
        Random r = new Random();

        for (int i = 0; i < 10; i++)
            st.Push(r.Next(10, 90));
        
        st.RemoveOdd();
        ;
        MyStack res = st.Sort();
        ;*/

        MyQueue q = new();
        Random r = new Random();

        for (int i = 0; i < 10; i++)
            q.Enqueue(r.Next(10, 90));

        while (!q.IsEmpty())
        {
            Console.WriteLine(q.Dequeue().data);
        }
    }
}
