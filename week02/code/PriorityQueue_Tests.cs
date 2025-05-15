using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add four values in the queue
    // priorityQueue.Enqueue("Thamara", 9);
    //     priorityQueue.Enqueue("God", 10);
    //     priorityQueue.Enqueue("Bruno", 9);
    //     priorityQueue.Enqueue("University", 8);
    

    // Expected Result: the function deques the item with highest priority
    //which is only one in this case: "God".


    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();



        priorityQueue.Enqueue("Thamara", 9);
        priorityQueue.Enqueue("God", 10);
        priorityQueue.Enqueue("Bruno", 9);
        priorityQueue.Enqueue("University", 8);

        var deque = priorityQueue.Dequeue();
        var expected = "God";

        Assert.AreEqual(expected, deque);


    }

    [TestMethod]
    // Scenario: Add four values to the queue, two values with the same//
    //highest priority. The function gets the first one of these, closest to the front and removes it.

    // Expected Result: out of the two items with the highest priority ( Thamara and Bruno)
    // only the first one (Thamara), will be removed
    
    // Defect(s) Found: In the if statement inside the for loop in the Dequeue function, ">=" was replaced by ">".//
    //This made it so that the highest priority item is only changed when the priority is higher than the last one, not equal
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Thamara", 9);
        priorityQueue.Enqueue("Cousins", 7);
        priorityQueue.Enqueue("Bruno", 9);
        priorityQueue.Enqueue("University", 8);

        var deque = priorityQueue.Dequeue();
        var expected = "Thamara";

        Assert.AreEqual(expected, deque);



    }






    [TestMethod]
    //Scenario: Add two items to the queue and remove three to check it the error is thrown when removing from an empty queue
    //Expected result: Exception willl be thrown on the third call of Dequeue(). 
    //defects found: Adding "_queue.RemoveAt(highPriorityIndex);"   so that dequeue actually removes the item from the queue
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bruno", 9);
        priorityQueue.Enqueue("University", 8);

        priorityQueue.Dequeue();
        priorityQueue.Dequeue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());


        Assert.AreEqual("The queue is empty.", exception.Message);


    }

    // Add more test cases as needed below.
}