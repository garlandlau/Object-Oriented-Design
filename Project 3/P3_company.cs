// Garland Lau
// CPSC 3200-01
// 2/13/24
// P3
// company.cs


using p3;
using System;
using System.Collections.Generic;

namespace P3
{
    class Company
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
            set { _companyEmployees = value; }
        }

        public List<Team> companyTeams
        {
            get { return _companyTeams; }
            set { _companyTeams = value; }
        }

        public Company(string newName, List<Employee> newCompEmp, List<Team> newCompTeams)
        {
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
