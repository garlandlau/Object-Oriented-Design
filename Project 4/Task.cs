// Garland Lau
// CPSC 3200-01
// P5
// Task.cs

using P5;
using System;
using System.Collections.Generic;

namespace P5{
/*
* Class Invariants
* 1) requires unique task names, team names
* 2) baseTime must be positive
* 3) Skill levels must be positive
*/    
public class Task
{
    private string _name = "";
    private string _description = "";
    private int _baseTime = 0;
    private bool _isDone = false;
    private Dictionary<Skill, int> _taskSkills = new Dictionary<Skill, int>();
    private int basicLevel = 1;
    public string name {
        get {return _name;} 
        set {_name = value;}
    }
    
    public string description {
        get {return _description;} 
        set {_description = value;}
    }

    public int baseTime {
        get {return _baseTime;} 
        set {_baseTime = value;}
    }
    
    public bool isDone {
        get {return _isDone;} 
        set {_isDone = value;}
    }

    public Dictionary<Skill, int> taskSkills {
        get { return _taskSkills; }
        set
        {
            HashSet<Skill> uniqueSkills = new HashSet<Skill>();
            foreach (var skill in value)
            {
                if (!uniqueSkills.Add(skill.Key))
                {
                    throw new ArgumentException("Duplicate skill found in Tasks.");
                    _taskSkills[skill.Key] = Math.Max(basicLevel, skill.Value);
                }
            }
            _taskSkills = value;
        }
    }
    
    public Task(string newName, string newDescription, int newBaseTime, Dictionary<Skill, int> newTaskSkills )
    {
        if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newDescription))
        {
            throw new ArgumentException("Task name or description cannot be empty or whitespace.");
        }

        if (newBaseTime <= 0)
        {
            throw new ArgumentException("Task base time must be greater than 0.");
        }
        
        name = newName;
        description = newDescription;
        baseTime = newBaseTime;
        taskSkills =  newTaskSkills;
    }

    public void updateAsDone()
    {
        isDone = true;
    }

    public void updateDescription(string newDescription){
        description = newDescription;
    }

    }
}