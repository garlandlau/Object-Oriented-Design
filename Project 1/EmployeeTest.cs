// Garland Lau
// CPSC 3200-01
// 1/14/24
// P1
// EmployeeTest.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1;

namespace UnitTests
{
[TestClass]
public class EmployeeTest
{
    [TestMethod]
    public void createEmployeeWOName()
    {
    // Registration
        Employee emp = new Employee();
        // Verification
        Assert.IsNotNull(emp);
        Assert.IsNull(emp.empHasSkills);
        Assert.AreEqual(emp.empWorkHours, 0.0);
    }

    [TestMethod]
    public void createEmployeeWOSkills()
    {
        // Setup
        string eName = "John Smith";
        double eWorkHours = 10.0;
        Dictionary<string, int> emptySkills = new Dictionary<string, int> { };
        // Execution
        Employee emp = new Employee(eName, eWorkHours, emptySkills);
        // Verification
        Assert.IsNull(empHasSkills);
        Assert.IsNotNull(emp);
    }

    [TestMethod]
    public void createEmployeeSuccessful()
    {
        // Setup
        string eName = "John Smith";
        double eWorkHours = 3.0;
        Dictionary<string, int> empSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        // Execution
        EmployeeTest emp = new Employee(eName, eWorkHours, empSkills);
        // Verification
        Assert.IsNotNull(emp.empHasSkills);
        Assert.IsNotNull(emp);
    }

    [TestMethod]
    public void estimateTaskTimePass()
    {
        // Setup
        string tName = "Task 3";
        string tDescription = "Task test case.";
        double tBaseTime = 3.0;
        Dictionary<string, int> tSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        Task task = new Task(tName, tDescription, tBaseTime, tSkills);
        string eName = "John Smith";
        double eWorkHours = 3.0;
        Dictionary<string, int> empSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        EmployeeTest emp = new Employee(eName, eWorkHours, empSkills);
        // Execution
        emp.estimateTaskTime(task);
        // Verification
        Assert.IsNotNull(emp.estimateTaskTime(task));
    }

    [TestMethod]
    public void estimateTaskTimeFail()
    {
        // Setup
        string tName = "Task 3";
        string tDescription = "Task test case.";
        double tBaseTime = 3.0;
        Dictionary<string, int> tSkills = new Dictionary<string, int> { };
        Task task = new Task(tName, tDescription, tBaseTime, tSkills);
        string eName = "John Smith";
        double eWorkHours = 3.0;
        Dictionary<string, int> empSkills = new Dictionary<string, int> 
        { {"Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        EmployeeTest emp = new Employee(eName, eWorkHours, empSkills);
        // Execution
        emp.estimateTaskTime(task);
        // Verification
        Assert.IsNull(emp.estimateTaskTime(task));
        Assert.IsNull(task);
    }
}

    [TestMethod]
    public void completeTaskPass()
    {
        // Setup
        string tName = "Task 3";
        string tDescription = "Task test case.";
        double tBaseTime = 3.0;
        Dictionary<string, int> tSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        Task task = new Task(tName, tDescription, tBaseTime, tSkills);
        string eName = "John Smith";
        double eWorkHours = 3.0;
        Dictionary<string, int> empSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        EmployeeTest emp = new Employee(eName, eWorkHours, empSkills);
        // Execution
        emp.completeTask(task);
        // Verification
        Assert.IsNotNull(emp.completeTask(task));
        Assert.IsNotNull(task);
    }

    [TestMethod]
    public void completeTaskFail()
    {
        // Setup
        string tName = "Task 3";
        string tDescription = "Task test case.";
        double tBaseTime = 3.0;
        Dictionary<string, int> tSkills = new Dictionary<string, int> { };
        Task task = new Task(tName, tDescription, tBaseTime, tSkills);
        string eName = "John Smith";
        double eWorkHours = 3.0;
        Dictionary<string, int> empSkills = new Dictionary<string, int>
        { { "Typing", 1 }, { "Reading", 2 }, { "Writing", 3 } };
        EmployeeTest emp = new Employee(eName, eWorkHours, empSkills);
        // Execution
        emp.completeTask(task);
        // Verification
        Assert.IsNull(emp.completeTask(task));
        Assert.IsNull(task);
    }
}
