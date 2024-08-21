// Garland Lau
// CPSC 3200-01
// P5
// IOrgChange.cs

using P5;
using System;
using System.Collections.Generic;

namespace P5{

/*
* Class Invariants:
* 1) must include ApplY() and valid Company
*/

public interface IOrgChange
{
    public void Apply(Company company);
}

/*
* Class Invariants:
* 1) requires a person Name, that's not already an employee
* 2) The list of all skills should include more than 3
*/

public class HireOperation : IOrgChange
{
    private string _personName;
    
    // Access existingSkills Dictionary from Skill.cs
    public Dictionary<string, Skill> existingSkills;
    
    

    public HireOperation(string personName)
    {
        _personName = personName;
    }

	/*
	* Pre-conditions:
	* -the new employee is not already in the company
	* Post-conditions:
	* -new employee is added to company, with 3 random skills and levels
	*/
    public void Apply(Company company)
    {
        if(existingSkills.Count < 3 )
        {
            Skill type = new Skill("Typing", "Typing on a keyboard");
            Skill write = new Skill("Writing", "Writing on paper");
            Skill draw = new Skill("Drawing", "Drawing pictures on papers");
        }
    
        Random random = new Random();
        List<Skill> skillsList = new List<Skill>(existingSkills.Values);
        Dictionary<Skill, int> randomSkill = new Dictionary<Skill, int>();
        
        // Shuffle skill list to get random skill order
        for (int i = 0; i < skillsList.Count; i++)
        {
            int index = random.Next(i, skillsList.Count);
            Skill temp = skillsList[i];
            skillsList[i] = skillsList[index];
            skillsList[index] = temp;
        }

        // Create randomSkill dictionary with 3 Skills and random level between 1-10
        for (int i = 0; i < 3; i++)
        {
            Skill randomSkillKey = skillsList[i];
            int randomSkillValue = random.Next(1, 11);
            randomSkill.Add(randomSkillKey, randomSkillValue);
        }
        
        Employee newEmp = new Employee(_personName, 0, randomSkill);
        company.hireEmployee(newEmp);
    }
}


/*
* Class Invariants:
* 1) requires a team Name, that's not already in company
*/
public class CreateTeamOperation : IOrgChange
{
    private string _teamName;

    public CreateTeamOperation(string teamName)
    {
        _teamName = teamName;
    }
	
	/*
	* Pre-conditions:
	* -the new team is not already in the company
	* Post-conditions:
	* -a new team is created, with zero employees
	*/
    public void Apply(Company company)
    {
        company.buildTeam(_teamName, new List<Employee>());
    }
}


/*
* Class Invariants:
* 1) requires an existing employee name
* 2) requires an existing team name
*/
public class TransferOperation : IOrgChange
{
    private string _empName;
    private string _newTeamName;

    public TransferOperation(string empName, string newTeamName)
    {
        _empName = empName;
        _newTeamName = newTeamName;
    }

	/*
	* Pre-conditions:
	* -the employee already exists
	* -the employee is a part of a company and an old team
	* Post-conditions:
	* -the employee is part of the new team
	* -employee is unassigned from the old team
	*/
    public void Apply(Company company){
        Employee emp = company.returnEmployee(_empName);
        if (emp == null)
        {
            throw new ArgumentException("Employee does not exist");
        }
        
        company.unassignEmployee(emp);
        
        Team newTeam = company.returnTeam(_newTeamName);
        if (newTeam != null)
        {
            newTeam.addEmployee(emp);
        }
    }
}
}