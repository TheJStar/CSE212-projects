using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: the highest value person is returned
    // Expected Result: Tim
    // Defect(s) Found: 
    public void TestPriorityQueue_GetHighest()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var prioritizedValue = priorityQueue.Dequeue();
        Assert.AreEqual("Tim", prioritizedValue);
    }

    [TestMethod]
    // Scenario: if there are 2 (or more) highest values the first one in queue is returned
    // Expected Result: Tim
    // Defect(s) Found: was not getting to the last member of the queue, would Dequeue the last highest member
    public void TestPriorityQueue_MoreThanOneHighest()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("George", 5);

        var prioritizedValue = priorityQueue.Dequeue();
        Assert.AreEqual("Tim", prioritizedValue);
    }

    [TestMethod]
    // Scenario: if there is nothing in the queue thwrow an Exception
    // Expected Result: "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
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

    // Add more test cases as needed below.
}