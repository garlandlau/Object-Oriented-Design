// Garland Lau
// CPSC 3200-01
// P5
// Team.cs

using P5;
using System;
using System.Collections.Generic;

namespace P5{

public class Team
{
/*
* Class Invariants
* 1) requires unique team names and employee names
* 2) Team has a list of Employees 
* 3) Team can add and remove employees from teams
* 4) Estimate Team Time uses all employee skills
*/    
    private string _name = "";
    private List<Employee> _teamEmployees = new List<Employee>();

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }

    public List<Employee> teamEmployees
    {
        get { return _teamEmployees; }
        set
        {
            HashSet<Employee> uniqueEmployees = new HashSet<Employee>(value);
            if (uniqueEmployees.Count != value.Count)
            {
                throw new ArgumentException("Duplicate employees in teams.");
            }
            _teamEmployees = value;
            
        }
    }

    public Team(string newName, List<Employee> newTeamEmp)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Company name cannot be empty or whitespace.");
        }
        name = newName;
        teamEmployees = newTeamEmp;
    }

    public string getName() { return name; }
    public int getNumTeamMembers() { return teamEmployees.Count; }

    public int estimateTeamTime(Task task)
    {
        int totalTime = 0, avgTime = 0, individualTime = 0;
        int teamSize = teamEmployees.Count;
 
        foreach (var emp in teamEmployees)
        {
            individualTime = emp.estimateTaskTime(task);
            totalTime += individualTime;
        }
        avgTime = totalTime / teamSize;
        return avgTime;
    }

    public void addEmployee(Employee emp)
    {
        teamEmployees.Add(emp);
    }

    public void removeEmployee(string name)
    {
        teamEmployees.RemoveAll(emp => emp.name == name);
    }
}
}