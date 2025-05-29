using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        // Solution:
        // Create new node
        Node newNode = new(value);

        // If the list is empty, then point both head and tail to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }

        // If the list is not empty, then only the tail will be affected
        else
        {
            _tail.Next = newNode; // Connect the current tail to the new node
            newNode.Prev = _tail; // Connect the new node to the current tail   
            _tail = newNode; // Update the tail to point to the new node
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        // Solution:
        // If the list has only one item in it, then set the head and tail
        // to null resulting in an empty list. This condition will also
        // cover an empty list. Its okay to set to null again
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }

        // If the list has more than one item in it, then only the tail 
        // will bee affected
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // Disconnect the second to the last tail from the last node
            _tail = _tail.Prev; // Update the tail to point to the second to last node
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        // Solution:
        Node? current = _head; // Start at the head of the list
        while (current is not null)
        {
            if (current.Data == value)
            {
                // If the node to remove is the head
                if (current == _head)
                {
                    RemoveHead();
                }
                // If the node to remove is the tail
                else if (current == _tail)
                {
                    RemoveTail();
                }
                // If the node is in the middle
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                return; // Only remove the first occurrence
            }
            current = current.Next;
        }
    }


    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        // Solution:
        Node? current = _head; // Start at the head of the list
        while (current is not null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue; // Replace the value in the current node
            }
            current = current.Next; // Move to the next node
        }
    }
    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        // Solution:
        var curr = _tail; // Start at the end since this is a backward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide each item to the user
            curr = curr.Prev; // Go backward in the linked list  
        }
       // yield return 0; // replace this line with the correct yield return statement(s)
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}

// What is the difference between a linked list and a dynamic array?
// A linked list is a collection of nodes where each node points to the next node, 
// allowing for efficient insertions and deletions. A dynamic array is a contiguous block of memory
// that can grow or shrink, but requires shifting elements for insertions and deletions, 
// which can be less efficient.

// What is one of the strengths of a linked list?
// One of the strengths of a linked list is that it allows for efficient insertions and deletions 
// at any position in the list without needing to shift elements, as is required in a dynamic array. 
// This makes linked lists particularly useful for applications where frequent modifications to the
// collection are expected.

// What is one of the drawbacks of a linked list?
// One of the drawbacks of a linked list is that it requires more memory per element due to
// the storage of additional pointers (next and previous) for each node, which can lead to
// higher overhead compared to a dynamic array. Additionally, accessing elements in a linked list 
// is generally slower than in a dynamic array because it requires traversing the list sequentially 
// rather than direct indexing.