/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test 1
        // Scenario: Create a customer service queue with a maximum size of 2. Try to add 3 customers.
        // Expected Result: The system should display an error message when trying to add the 3rd customer.
        Console.WriteLine("Test 1: Full Queue Error");
        var cs1 = new CustomerService(2);
        cs1.AddNewCustomer(); // Add a customer
        cs1.AddNewCustomer(); // Add another customer
        cs1.AddNewCustomer(); // This should print "Maximum Number of Customers in Queue."
        Console.WriteLine(cs1);
        Console.WriteLine("=================");

        // Test 2
        // Scenario: Try to serve a customer when the queue is empty.
        // Expected Result: Should display an error message indicating no customers to serve.
        Console.WriteLine("Test 2: Empty Queue Error");
        var cs2 = new CustomerService(10);
        cs2.ServeCustomer(); // Should print "No customers in the queue to serve."
        Console.WriteLine("=================");

        // Test 3
        // Scenario: Validate that the default size (10) is applied if the user passes an invalid value (0 or negative).
        // Expected Result: The max_size should be 10.
        Console.WriteLine("Test 3: Invalid Default Size");
        var cs3 = new CustomerService(0);
        Console.WriteLine(cs3); // Should show max_size=10
        Console.WriteLine("=================");
        
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 1");

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 2");

        // Defect(s) Found: 

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
        // BUG 1 FIXED: Use >= so it doesn't allow more than the max number of customers in the queue
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

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // BUG 3 FIXED: Check if the queue is empty before trying to serve a customer
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in the queue to serve.");
            return;
        }

        // BUG 2 FIXED: Read the first customer in the queue and remove it from the queue
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
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