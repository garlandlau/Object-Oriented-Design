// Garland Lau
// CPSC 3200-01
// 1/14/24
// P1
// Employee.cs
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace P1
{
    class Employee
    {
    /* Class Invariants
    * 1) Employee Names should be unique and not empty
    * 2) The empWorkHours should not be negative
    * 3) The _empHasSkills should not be null
    * Implementation Invariant
    * 1) _empHasSkills requires an employee to have a skill 0 or 1 times (no
    duplicates)
    * 2) the skill level should be non-negative
    * Interface Invariant
    * 1) A default constructor is called when not enough info is provided for
    Employee
    * constructor. A basic name and empty dictionary is provided
    */
    private string _empName;
    private double _empWorkHours;
    private Dictionary<string, int> _empHasSkills;
    public string empName
    {
        get { return _empName; }
        private set { _empName = value; }
    }
    public double empWorkHours
    {
        get { return _empWorkHours; }
        private set { _empWorkHours = value; }
    }
    public Dictionary<string, int> empHasSkills
    {
        get { return _empHasSkills; }
        private set { _empHasSkills = value; }
    }
    public Employee()
    {
        empName = "Basic Employee Name";
        empWorkHours = 0.0;
        empHasSkills = new Dictionary<string, int>();
    }
    public Employee(string eName, double eWorkHours, Dictionary<string, int> eHasSkills)
    {
        empName = eName;
        empWorkHours = eWorkHours;
        empHasSkills = eHasSkills;
    }
    // If Skill of Employee > Task, Then skill estimate = taskTime / 2
    // If Skill of Employee = Task, Then skill estimate = taskTime
    // If Skill of Employee < Task , or Employee does not have skill, Then
    skill estimate = taskTime * 2
    /*Pre-Conditions:
    * 1) task is not empty and valid
    * 2) taskNeedSkills is not empty and valid
    *Post-Conditons:
    * 1) The skill difference will either be 1/2* base time, 1* base time, or
    2* base time
    * 2) The avgEstimate is total skill differences / num of skills
    * 3) A positive estimate is always returned
    */
    public double estimateTaskTime(Task task)
    {
        double avgEstimate = 0;
        foreach (var taskSkills in task.taskNeedSkills){
            string skillName = taskSkills.Key;
            int tSLevel = taskSkills.Value;

            if(empHasSkills.ContainsKey(skillName))
            {
                int empSkillLevel = empHasSkills[skillName];
                double skillDiff = 0;
                if (empSkillLevel > tSLevel)
                {
                    skillDiff = task.taskBaseTimeHours / 2;
                }
                else if (empSkillLevel < tSLevel)
                {
                    skillDiff = task.taskBaseTimeHours * 2;
                }
                else
                {
                    skillDiff = task.taskBaseTimeHours;
                }
                avgEstimate += skillDiff;
            }else{
                double skillDiff = 2 * task.taskBaseTimeHours;
                avgEstimate += skillDiff;
            }
        }
        return avgEstimate /task.taskNeedSkills.Count;
    }

    // If skill of employee < task, or employee does not have skill
    // Then skillGain = 2
    // If skill of employee >= task
    // Then skillGain = 1
    /*Pre-Conditions:
    * 1) task is not empty and valid
    * 2) task isDone == true
    * 3) taskNeedSkills is not empty and valid
    * 4) empHasSkills is not empty and valid
    *Post-Conditons:
    * 1) Task isDone will be true
    * 2) Employee skills required for task will increase by 1 or 2
    * 3) The skillGain increases by 1 if employee skill level is >= task skill
    level
    * The skillGain increases by 2 if employee does not have task skill
    * or emp skill lvl < task skill lvl
    */
    public void completeTask(Task task)
    {
        if (!task.isDone)
        {
            double estimatedTime = estimateTaskTime(task);
            task.setAsDone();
            empWorkHours += estimatedTime;
            foreach (var taskSkills in task.taskNeedSkills)
            {
                string skillName = taskSkills.Key;
                int taskDifficulty = taskSkills.Value;
                if (empHasSkills.ContainsKey(skillName))
                {
                    double empSkillLevel = empHasSkills[skillName];
                    int skillGain = 0;
                    if(empSkillLevel >= taskDifficulty)
                    {
                        skillGain = 1;
                    }
                    else
                    {
                        skillGain = 2;
                    }
                    empHasSkills[skillName] += skillGain;
                }else{
                    int skillGain = 2;
                    empHasSkills[skillName] += skillGain;
                }
            }
        }
    }
    }
}
