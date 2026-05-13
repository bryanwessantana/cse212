using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items A (1), B (5), C (2) to the priority queue.
    // Expected Result: B (priority 5) should be removed first.
    // Defect(s) Found: The original code was using '>' to compare priorities, which caused it 
    // to return the first item in the list instead of the one with the highest priority.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Test FIFO in case of a tie: Add items A (10), B (10), C (5).
    // Expected Result: A should be removed before B because it arrived first.
    // Defect(s) Found: The code was using '>=' which picked the last item in case of a tie.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 10);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 5);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }
}