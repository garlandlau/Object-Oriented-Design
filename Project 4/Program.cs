// Garland Lau
// CPSC 3200-01
// P5
// Program.cs

using P5;
using System;
using System.Collections.Generic;
using System.IO;

namespace P5
{
    public class Program
    {
        static void main(string[] args)
        {
            // Skills
            Skill type = new Skill("Typing", "Typing on a keyboard");
            Skill write = new Skill("Writing", "Writing on paper");
            Skill draw = new Skill("Drawing", "Drawing pictures on papers");
            
            // Skills from different Derived Skill classes
            RandomSkill rollDice = new RandomSkill("rollDice", "Rolling dice for gambling", new Random(10));
            DefaultSkill driveCar = new DefaultSkill("driveCar", "Driving a car");
            ExtendSkill driveTruck = new ExtendSkill("driveTruck", "Driving a truck");
            
            // Tasks using derived skills
            Dictionary<Skill, int> task1_skill = new Dictionary<Skill, int> {{type, 1},{ driveCar, 2} };
            Task typeCar = new Task("typeCar", "Typing while driving a car", 5, task1_skill);
            
            Dictionary<Skill, int> task2_skill = new Dictionary<Skill, int> {{write, 5},{ driveTruck, 5} };
            Task writeTruck = new Task("writeTruck", "Writing while driving a truck", 10, task2_skill);
            
            Dictionary<Skill, int> task3_skill = new Dictionary<Skill, int> {{draw, 4},{ rollDice, 1} };
            Task drawDice = new Task("drawDice", "Drawing while rolling dice", 15, task3_skill);

            List<Task> companyTask = new List<Task> { typeCar, writeTruck, drawDice };
            
            // Empty Company
            List<Employee> newCompanyEmp = new List<Employee>();
            List<Team> newCompanyTeam = new List<Team>();
            Company company1 = new Company("company1", newCompanyEmp, newCompanyTeam);
            
            // Read in file
            if (args.Length == 0)
            {
                throw new ArgumentException("File name is not valid.");
            }
            
            // Run list of commands
            foreach (string line in File.ReadLines(args[0]))
            {
                // Extract Operation(h, c, t), Employee name, and Team Name (opitional)
                string[] parts = line.Split(' ');
                char operation = parts[0][0];
                string[] names = new string[parts.Length - 1];
                Array.Copy(parts, 1, names, 0, names.Length);
                
                // Preform Operations (hire, create, transfer)
                switch(operation){
                    case 'h':
                        HireOperation hireOperation = new HireOperation(names[0]);
                        hireOperation.Apply(company1);
                        break;
                    case 'c':
                        CreateTeamOperation createTeamOperation = new CreateTeamOperation(names[0]);
                        createTeamOperation.Apply(company1);
                        break;
                    case 't':
                        TransferOperation transferOperation = new TransferOperation(names[0], names.Length > 1 ? names[1] : null);
                        transferOperation.Apply(company1);
                        break;
                    default: 
                        Console.WriteLine("Invalid operation");
                        break;
                }
                
                // Prints out each Team's cost estimate for each Task
                // Will still print if there's no teams, team members, or tasks
                Console.WriteLine($"Line: {line}");
                foreach (Team team in company1.companyTeams)
                {
                    Console.WriteLine($"Team: {team.name}");
                    foreach (Task task in companyTask)
                    {
                        Console.WriteLine($"Task: {task.name}, Estimated Cost: {team.estimateTeamTime(task)}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}