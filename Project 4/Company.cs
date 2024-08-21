// Garland Lau
// CPSC 3200-01
// P5
// Company.cs

using P5;
using System;
using System.Collections.Generic;

namespace P5{
/*
* Class Invariants
* 1) requires unique company names, team names, and employee names
* 2) Company has a list of Employees and Teams
* 3) Company add and remove employees from Company and Teams
*/    
public class Company
{
    private string _name = "";
    private List<Employee> _companyEmployees = new List<Employee>();
    private List<Team> _companyTeams = new List<Team>();

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }

    public List<Employee> companyEmployees
    {
        get { return _companyEmployees; }
        set
        {
            HashSet<Employee> uniqueEmployees = new HashSet<Employee>(value);
            if (uniqueEmployees.Count != value.Count)
            {
                throw new ArgumentException("Duplicate employees in company.");
            }
            _companyEmployees = value;
        }
    }

    public List<Team> companyTeams
    {
        get { return _companyTeams; }
        set
        {
            HashSet<Team> uniqueCompTeams = new HashSet<Team>(value);
            if (uniqueCompTeams.Count != value.Count)
            {
                throw new ArgumentException("Duplicate teams in company.");
            }
            _companyTeams = value;
        }
    }

    public Company(string newName, List<Employee> newCompEmp, List<Team> newCompTeams)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("Company name cannot be empty or whitespace.");
        }

        name = newName;
        companyEmployees = newCompEmp;
        companyTeams = newCompTeams;
    }

    public void hireEmployee(Employee emp)
    {
        companyEmployees.Add(emp);
    }

    public void fireEmployee(Employee emp)
    {
        string empName = emp.getName();

        foreach (var team in companyTeams)
        {
            team.removeEmployee(empName);
        }

        companyEmployees.Remove(emp);
    }

    public void unassignEmployee(Employee emp)
    {
        string empName = emp.getName();

        foreach (var team in companyTeams)
        {
            team.removeEmployee(empName);
        } 
    }
    
    public void buildTeam(string newTeamName, List<Employee> newTeamEmp)
    {
        companyTeams.Add(new Team(newTeamName, newTeamEmp));
    }

    public void destroyTeam(string teamName)
    {
        var teamToDestroy = companyTeams.Find(team => team.name == teamName);
        if(teamToDestroy != null)
        {
            companyTeams.Remove(teamToDestroy);
        }
    }

    public Employee returnEmployee(string empName)
    {
        return companyEmployees.Find(emp => emp.name == empName);
        
    }

    public Team returnTeam(string teamName)
    {
        return companyTeams.Find(team => team.name == teamName);
    }
} 
}