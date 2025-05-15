using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: size = 0
        // Expected Result:  queue size = 10
        Console.WriteLine("queue size 0");
        var cs = new CustomerService(0);
        Console.WriteLine(cs._maxSize);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("queue negative size");

        var cs2 = new CustomerService(-12);
        Console.WriteLine(cs._maxSize);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        Console.WriteLine("Add new customer and serve him");

        var cs3 = new CustomerService(8);

        cs3.AddNewCustomer();
        Console.WriteLine(cs3._queue.Count);
        cs3.ServeCustomer();
        Console.WriteLine(cs3._queue.Count);



        Console.WriteLine("=================");


        Console.WriteLine("Add new customer with queue full");

        // var cs4 = new CustomerService(2);
        // cs4.AddNewCustomer();
        // cs4.AddNewCustomer();
        // cs4.AddNewCustomer();






        Console.WriteLine("=================");


        Console.WriteLine("serve customer with empty queue");

        var cs5 = new CustomerService(2);


        cs5.ServeCustomer();


        

         Console.WriteLine("=================");

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize - 1) {
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
    private void ServeCustomer() {
        if (_queue.Count == 0)
        {
            Console.WriteLine("Error, Queue is empty");
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
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}