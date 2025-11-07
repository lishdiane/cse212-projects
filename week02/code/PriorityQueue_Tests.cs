using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The following tasks are added to a queue in the correct order - Task1(1), Task2(2), task3(1);
    // Expected Result: task1, task2, task3; 
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var task1 = new PriorityItem("Task1", 1);
        var task2 = new PriorityItem("Task2", 2);
        var task3 = new PriorityItem("Task3", 3);

        PriorityItem[] expectedResult = { task1, task2, task3 };

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(task1.Value, task1.Priority);
        priorityQueue.Enqueue(task2.Value, task2.Priority);
        priorityQueue.Enqueue(task3.Value, task3.Priority);

        string queueString = priorityQueue.ToString();
        queueString = queueString.Trim('[', ']');
        string[] tasks = queueString.Split(", ");

        List<string> values = new List<string>();
        foreach (var item in tasks)
        {
            var value = item.Split(" ")[0];
            values.Add(value);
        };

        for (int i = 0; i < expectedResult.Count(); i++)
        {
            Debug.WriteLine($"{expectedResult[i].Value} {values[i]}");
            Assert.AreEqual(expectedResult[i].Value, values[i]);
        };


    }

    [TestMethod]
    // Scenario: Create a queue with 3 tasks and dequeues them based on highest priority.
    // Expected Result: Task3(3), Task2(2), Task1(1)
    // Defect(s) Found: It wasn't checking the last item in the queue because it was subtracting
    // 1 from the count. It also wasn't removing the item from the queue.
    public void TestPriorityQueue_2()
    {
        var task1 = new PriorityItem("Task1", 1);
        var task2 = new PriorityItem("Task2", 2);
        var task3 = new PriorityItem("Task3", 3);

        PriorityItem[] expectedResult = { task3, task2, task1 };

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(task1.Value, task1.Priority);
        priorityQueue.Enqueue(task2.Value, task2.Priority);
        priorityQueue.Enqueue(task3.Value, task3.Priority);

        Assert.AreEqual(priorityQueue.Dequeue(), expectedResult[0].Value);
        Assert.AreEqual(priorityQueue.Dequeue(), expectedResult[1].Value);
        Assert.AreEqual(priorityQueue.Dequeue(), expectedResult[2].Value);

    }

    [TestMethod]
    // Scenario: 3 tasks (task1(3), task2(2), task3(3); ) are added and removed by priority and position in queue. 
    // Expected Result: task1, task3, task2; 
    // Defect(s) Found: Priority index was changing if it was equal to highest index.
    public void TestPriorityQueue_3()
    {
        var task1 = new PriorityItem("Task1", 3);
        var task2 = new PriorityItem("Task2", 1);
        var task3 = new PriorityItem("Task3", 3);

        PriorityItem[] expectedResult = { task1, task3, task2 };

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(task1.Value, task1.Priority);
        priorityQueue.Enqueue(task2.Value, task2.Priority);
        priorityQueue.Enqueue(task3.Value, task3.Priority);

        Assert.AreEqual(priorityQueue.Dequeue(), expectedResult[0].Value);
        Assert.AreEqual(priorityQueue.Dequeue(), expectedResult[1].Value);
        Assert.AreEqual(priorityQueue.Dequeue(), expectedResult[2].Value);
    }


    [TestMethod]
    // Scenario: An empty queue is dequeued.
    // Expected Result: an InvalidOperationException error thrown.
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());

    }
}