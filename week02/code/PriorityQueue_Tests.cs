using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue them. Higher priority should come out first.
    // Expected Result: Items dequeued in priority order: High (3), Medium (2), Low (1)
    // Defect(s) Found: Loop in Dequeue() uses _queue.Count - 1 instead of _queue.Count, 
    // so it doesn't check the last item in the queue. Also, the item is not removed from the queue after dequeue.
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same priority. The first one added should come out first (FIFO).
    // Expected Result: Items with same priority dequeued in order added: First, Second, Third
    // Defect(s) Found: Loop doesn't check last item, and uses >= instead of >, so later items 
    // with same priority are chosen instead of earlier ones (violates FIFO).
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of priorities with duplicates. Test that highest priority comes first, 
    // and among same priority, FIFO order is maintained.
    // Expected Result: High1 (priority 5), High2 (priority 5), Med (priority 3), Low (priority 1)
    // Defect(s) Found: Same defects as above - doesn't check last item, doesn't remove items, 
    // and uses >= causing wrong FIFO order.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High1", 5);
        priorityQueue.Enqueue("Med", 3);
        priorityQueue.Enqueue("High2", 5);

        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("Med", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: No defect - this test passes correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Add items, dequeue some, add more, dequeue rest. Tests that queue state is maintained correctly.
    // Expected Result: First batch dequeued by priority, then new items dequeued by priority
    // Defect(s) Found: Items not removed from queue, so dequeuing returns same items repeatedly.
    public void TestPriorityQueue_InterleavedOperations()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());

        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 1);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test with negative and zero priorities
    // Expected Result: Higher numbers still have higher priority (0 > -1 > -5)
    // Defect(s) Found: Same loop and removal defects.
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("VeryLow", -5);
        priorityQueue.Enqueue("Zero", 0);
        priorityQueue.Enqueue("Low", -1);

        Assert.AreEqual("Zero", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
        Assert.AreEqual("VeryLow", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Single item queue
    // Expected Result: The single item is dequeued successfully
    // Defect(s) Found: If item is at last index, loop won't check it, but with single item at index 0, this might work.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 1);

        Assert.AreEqual("Only", priorityQueue.Dequeue());
    }
}
