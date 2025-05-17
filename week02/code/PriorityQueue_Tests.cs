using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several items with different priorities, then dequeue all
    // Expected Result: Items are dequeued in order of highest priority first (lowest number if lower is higher priority)
    // Defect(s) Found: Failed TestPriorityQueue_1 [43 ms]
    // Error Message:
    // Assert.Fail failed. Implement the test case and then remove this.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        // Enqueue items with different priorities
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 2);

        // Dequeue items and check the order
        Assert.AreEqual("B", priorityQueue.Dequeue()); // Priority 1
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Priority 2
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Priority 3
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority, then dequeue all.
    // Expected Result: Items with the same priority are dequeued in the order they were enqueued (FIFO for ties).
    // Defect(s) Found: Error Message:
    // Assert.Fail failed. Implement the test case and then remove this.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        // Enqueue items with the same priority
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        // Dequeue items and check the order
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}