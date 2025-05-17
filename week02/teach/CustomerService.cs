/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add customers until max size is reached
        // Expected Result: The last AddNewCustomer should trigger a "Maximum Number of Customers" message
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(2);

        Console.SetIn(new System.IO.StringReader("Alice\nA123\nCannot login\nBob\nB456\nForgot password\nCharlie\nC789\nSystem crash"));
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        cs1.AddNewCustomer(); // Should print error
        Console.WriteLine(cs1);

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Serve customer from non-empty queue
        // Expected Result: The first customer is served and removed from the queue
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(2);
        Console.SetIn(new System.IO.StringReader("Dan\nD111\nPayment issue"));
        cs2.AddNewCustomer();
        cs2.ServeCustomer(); // Should print Dan's details
        Console.WriteLine(cs2); // Should show an empty queue

        Console.WriteLine("=================");

        // Test 3: Serve from an empty queue
        // Scenario: Try to serve when no customers have been added
        // Expected Result: "No customers to serve."
        Console.WriteLine("Test 3: Serve from empty queue");
        var cs3 = new CustomerService(5);
        cs3.ServeCustomer();
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }
    // Defect(s) Found: No empty queue check in ServeCustomer

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers to serve.");
            return;
        }

        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
