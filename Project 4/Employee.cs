// Garland Lau
// CPSC 3200-01
// P5
// Employee.cs

using P5;
using System;
using System.Collections.Generic;

namespace P5{
/*
* Class Invariants
* 1) requires unique employee names
* 2) employees has a dictionary of Skills and skill levels
* 3) Estimate Time compares all Task Skills and Employee Skills levels
*/    

public class Employee
{
    private string _name = "";
    private int _workTime = 0;
    private Dictionary<Skill, int> _empSkills { get; set; } = new Dictionary<Skill, int>();
    private int basicLevel = 1;

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int workTime
    {
        get { return _workTime; }
        set { _workTime = value; }
    }

    public Dictionary<Skill, int> empSkills
    {
        get { return _empSkills; }
        set
        {
            HashSet<Skill> uniqueSkills = new HashSet<Skill>();
            foreach (var skill in value)
            {
                if (!uniqueSkills.Add(skill.Key))
                {
                    throw new ArgumentException("Duplicate skill found in Employees.");
                }
                _empSkills[skill.Key] = Math.Max(basicLevel, skill.Value);
            }
            _empSkills = value;
        }
    }

    public Employee(string newName, int newWorkTime, Dictionary<Skill, int> newEmpSkills)
	{
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Employee name cannot be empty or whitespace.");
        }

        if (newWorkTime < 0)
        {
            throw new ArgumentException("Employee work time must be greater than or equal to 0.");
        }

        name = newName;
		workTime = newWorkTime;
		empSkills = newEmpSkills;
	}

    public string getName() { return name; }

    public int estimateTaskTime(Task task)
    {
        int avg = 0, temp = 0;
        int taskTime = task.baseTime;

        int numSkills = task.taskSkills.Count;

        foreach (var taskSkill in task.taskSkills)
        {
            Skill skill = taskSkill.Key;
            int taskLevel = taskSkill.Value;
            int empLevel = 0;

            if (empSkills.ContainsKey(skill))
            {
                empLevel = empSkills[skill];

            }
            else
            {
                empSkills[skill] = basicLevel;
                empLevel = empSkills[skill];
            }

            temp = skill.CalculateCost(taskTime, taskLevel, empLevel);
            avg += temp;
        }

        avg = avg / numSkills;
        return avg;
    }

    public void completeTask(Task task)
    {
        if (!task.isDone)
        {
            int estimatedTime = estimateTaskTime(task);

            task.updateAsDone();
            workTime += estimatedTime;

            foreach (var taskSkill in task.taskSkills)
            {
                Skill skill = taskSkill.Key;
                int taskLevel = taskSkill.Value;
                int skillDiff = 0;

                int empSkillLevel = empSkills[skill];
                int skillGain = 0;

                if (empSkillLevel >= taskLevel)
                {
                    skillGain = 1;
                }
                else
                {
                    skillDiff = taskLevel - empSkillLevel;
                    if (skillDiff % 2 == 1)
                    {
                        skillDiff += 1;
                    }
                    skillGain = skillDiff / 2;
                }
                empSkills[skill] += skillGain;
            }
        }
    }
}
}