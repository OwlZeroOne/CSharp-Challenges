/*
    Implement a doubly linked list.

    Like an array, a linked list is a simple linear data structure. Several common data types can be implemented using linked lists, like queues, stacks, and associative arrays.

    A linked list is a collection of data elements called nodes. In a singly linked list each node holds a value and a link to the next node. In a doubly linked list each node also holds a link to the previous node.

    You will write an implementation of a doubly linked list. Implement a Node to hold a value and pointers to the next and previous nodes. Then implement a List which holds references to the first and last node and offers an array-like interface for adding and removing items:

    -   push (insert value at back);
    -   pop (remove value at back);
    -   shift (remove value at front).
    -   unshift (insert value at front);

    To keep your implementation simple, the tests will not cover error conditions. Specifically: pop or shift will never be called on an empty list.
*/
using System.Text;

public class DoublyLinkedList<T>
{
    private Node<T>? head, tail;
    private int size;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public DoublyLinkedList(T firstElement)
    {
        head = new Node<T>(firstElement, null, null);
        tail = head;
        size = 1;
    }

    /// <summary>
    /// Append a new node to the tail of the list.
    /// </summary>
    public void Push(T value)
    {
        if (IsEmpty())
        {
            head = new Node<T>(value, null, null);
            tail = head;
        }
        else
        {
            tail.Append(value);
            tail = tail.Next();
        }
        size++;
    }

    /// <summary>
    /// Remove an element from the tail of the list.
    /// </summary>
    public T Pop()
    {
        T value;

        // Throw exception if list is empty.
        if (IsEmpty()) throw new Exception("Attempt to pop from an empty list!");
        else
        {
            Node<T>? node = tail;
            // Pop this node if it has no surrounding nodes (head/first element) 
            if (head == tail)
            {
                value = node.Get();
                head = null;
                tail = null;
            }
            else
            {
                value = tail.Get();

                tail = tail.Previous();
                tail.Drop("next");
            }
            size--;
        }
        return value;
    }

    /// <summary>
    /// Prepend an element to the head of the list.
    /// </summary>
    public void Unshift(T value)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Is Empty");
            head = new Node<T>(value, null, null);
            tail = head;
        }
        else
        {
            head.Prepend(value);
            head = head.Previous();
        }
        size++;
    }

    /// <summary>
    /// Remove an element from the head of the list.
    /// </summary>
    public T Shift()
    {
        T value;

        // Throw exception if list is empty.
        if (IsEmpty()) throw new Exception("Attempt to shift from an empty list!");
        else
        {
            Node<T>? node = head;
            // Pop this node if it has no surrounding nodes (head/first element) 
            if (head == tail)
            {
                value = node.Get();
                head = null;
                tail = null;
            }
            else
            {
                value = head.Get();

                head = head.Next();
                head.Drop("previous");
            }
            size--;
        }
        return value;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    override public string ToString()
    {
        StringBuilder sb = new StringBuilder();
        Node<T>? node = head;

        sb.Append("[");
        while (node != null)
        {
            sb.Append(node.Get());
            sb.Append(node.Next() == null ? "": ",");
            node = node.Next();
        }
        sb.Append("]");

        return sb.ToString();
    }

    // private void ThrowsNullException(this Node<T> n)
    // {
    //     if (n == null) throw new NullReferenceException();
    // }
}

// *************************************************************************
// -------------------------------------------------------------------------
// *************************************************************************

class Node<T>
{
    private Node<T>? next, previous;
    private T elem;

    /// <summary>
    /// Initializes a node, setting its element and references to previous and next nodes.
    /// </summary>
    public Node(T elem, Node<T>? previous, Node<T>? next)
    {
        this.elem = elem;
        this.previous = previous;
        this.next = next;
    }

    /// <summary>
    /// Gets the element of the node.
    /// </summary>
    public T Get()
    {
        return elem;
    }

    /// <summary>
    /// Gets the next node from this node.
    /// </summary>
    public Node<T>? Next()
    {
        return next;
    }

    /// <summary>
    /// Gets the previous node of this node.
    /// </summary>
    public Node<T>? Previous()
    {
        return previous;
    }

    /// <summary>
    /// Add a new node after this node, provided <paramref name="next"/> is null.
    /// </summary>
    public void Append(T value)
    {
        if (next == null) next = new Node<T>(value, this, null);
        else throw new Exception("The reference to the next node is not null!");
    }

    /// <summary>
    /// Add a new node before this node, provided <paramref name="previous"/> is null.
    /// </summary>
    public void Prepend(T value)
    {
        if (previous == null) previous = new Node<T>(value, null, this);
        else throw new Exception("The reference to the previous node is not null!");
    }

    /// <summary>
    /// Given the parameter <paramref name="which"/>, drop the indicated node from the list, provided
    /// that the node at the reference is not null.
    /// </summary>
    public void Drop(string which)
    {
        switch (which)
        {
            case "next":
                if (next != null) next = null;
                else throw new Exception("The reference to the next node is null!");
                break;

            case "previous":
                if (previous != null) previous = null;
                else throw new Exception("The reference to the previous node is null!");
                break;
        }
    }
}