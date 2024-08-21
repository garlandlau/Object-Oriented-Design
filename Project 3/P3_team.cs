// Garland Lau
// CPSC 3200-01
// 2/13/24
// P3
// team.cs


using p3;
using System;
using System.Collections.Generic;


namespace P3
{
    public class Team
    {
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
            set { _teamEmployees = value; }
        }

        public Team(string newName, List<Employee> newTeamEmp)
        {
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