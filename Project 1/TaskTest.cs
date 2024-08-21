// Garland Lau
// CPSC 3200-01
// 1/14/24
// P1
// TaskTest.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1;

namespace UnitTests
{
[TestClass]
public class TaskTest
{
    [TestMethod]
    public void createTaskWOName()
    {
        // Setup
        // * None for default constructor
        // Execution
        Task task = new Task();
        // Verification
        Assert.IsNotNull(task);
    }

    [TestMethod]
    public void createTaskWOSkills()
    {
        // Setup
        string tName = "Task Test";
        string tDescription = "Task test case";
        double tBaseTime = 1.0;
        Dictionary<string, int> emptySkills = new Dictionary<string, int> { };
        // Execution
        Task task = new Task(tName, tDescription, tBaseTime, emptySkills);
        // Verification
        Assert.IsNull(task.taskNeedSkills);
        Assert.IsNotNull (task);
    }

    [TestMethod]
    public void createTaskSuccessful()
    {
        // Setup
        string tName = "Task 3";
        string tDescription = "Task test case.";
        double tBaseTime = 3.0;
        Dictionary<string, int> tSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        // Execution
        Task task = new Task(tName, tDescription, tBaseTime, tSkills);
        // Verification
        Assert.IsNotNull(task.taskNeedSkills);
        Assert.IsNotNull(task);
    }

    [TestMethod]
    public void markAsDonePass()
    {
        // Setup
        string tName = "Task 3";
        string tDescription = "Task test case.";
        double tBaseTime = 3.0;
        Dictionary<string, int> tSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        Task task = new Task(tName, tDescription, tBaseTime, tSkills);
        // Execution
        task.setAsDone();
        // Verification
        Assert.IsTrue(task.isDone);
        Assert.IsNotNull(task);
    }

    [TestMethod]
    public void markAsDoneFail()
    {
        // Setup
        string tName = "Task 3";
        string tDescription = "Task test case.";
        double tBaseTime = 3.0;
        Dictionary<string, int> tSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        Task task = new Task(tName, tDescription, tBaseTime, tSkills);
        task.setAsDone();
        // Execution
        task.setAsDone(); // Task is already marked as done
        // Verification
        Assert.IsTrue(task);
        Assert.IsNotNull(task);
    }
}
}
