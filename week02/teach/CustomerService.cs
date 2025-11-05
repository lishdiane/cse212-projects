/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The max size is >= 0 
        // Expected Result: The max size should default to 10
        Console.WriteLine("Test 1");

        var maxSize = new CustomerService(0);
        Console.WriteLine(maxSize);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: A new customer is added to the queue.
        // Expected Result: A new customer is enqueueed.
        Console.WriteLine("Test 2");

        var queue = new CustomerService(3);
        queue.AddNewCustomer();
        Console.WriteLine(queue);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 3
        // Scenario: A customer is added to a full queue.
        // Expected Result: An error message is displayed
        Console.WriteLine("Test 3");
        queue = new CustomerService(1);
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        queue.AddNewCustomer();

        // Defect(s) Found: changed to - queue.count <= max

        Console.WriteLine("=================");

        // Test 4
        // Scenario: A customer has been served. 
        // Expected Result: The customer info is dequeued and displayed. 
        Console.WriteLine("Test 4");

        queue = new CustomerService(3);
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        queue.AddNewCustomer();
        Console.WriteLine(queue);
        queue.ServeCustomer();
        queue.ServeCustomer();
        queue.ServeCustomer();
        Console.WriteLine(queue);

        // Defect(s) Found: Moved customer up and remove down

        Console.WriteLine("=================");

        // Test 5
        // Scenario: The queue is empty but a customer is being served.
        // Expected Result: An error message. 
        Console.WriteLine("Test 5");

        queue = new CustomerService(1);
        queue.ServeCustomer();

        // Defect(s) Found: Added a condition if queue is empty. 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
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
        if (_queue.Count >= _maxSize) {
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

        if (_queue.Count <= 0)
        {
            Console.WriteLine("There are no people in the queue.");
        }
        else
        {
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0);
        }
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