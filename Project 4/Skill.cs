// Garland Lau
// CPSC 3200-01
// P5
// Skill.cs

using P5;
using System;
using System.Collections.Generic;

namespace P5
{

/*
* Class Invariants
* 1) requires unique skill names
* 2) skill names and descriptions cannot be null
*/    
    public class Skill
    {
        private string _name = "";
        private string _description = "";
        private Dictionary<string, Skill> _existingSkills = new Dictionary<string, Skill>();

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Dictionary<string, Skill> existingSkills
        {
            get { return _existingSkills; }
            set { _existingSkills = value; }
        }

        public Skill(string newName, string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newDescription))
            {
                throw new ArgumentException("Skill name or description cannot be empty or whitespace.");
            }

            if (existingSkills.ContainsKey(newName))
            {
                throw new ArgumentException($"Skill with '{newName}' already exists. ");
            }

            name = newName;
            description = newDescription;
            existingSkills.Add(name, this);
        }


        public virtual int CalculateCost(int taskTime, int taskLevel, int empLevel)
        {
            int answer = 0;
            if (empLevel > taskLevel)
            {
                if (taskTime % 2 == 1)
                {
                    taskTime += 1;
                }

                answer = taskTime / 2;
            }
            else if (empLevel < taskLevel)
            {
                answer = taskTime * 2;
            }
            else
            {
                answer = taskTime;
            }

            return answer;
        }


        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(name);
            hash.Add(description);
            return hash.ToHashCode();
        }
        
        public override bool Equals(Skill other)
        {
            if (other != null && other.name == name && other.description == description)
            {
                return true;
            }

            return false;
        }
        
    }

	/*
* Class Invariants
* 1) Random number generator is passed in as a parameter
* 2) Random number is chosen between 1 and (employeee skill level + taskLevel)
* 3) Calculate Cost returns RandomNumber * taskTime
*/    
    class RandomSkill : Skill
    {
        private Random _random;

        public RandomSkill(string newName, string newDescription, Random random) :
            base(newName, newDescription)
        {
            _random = random;
        }

        public override int CalculateCost(int taskTime, int taskLevel, int empLevel)
        {
            int newLevel = _random.Next(1, empLevel + taskLevel);
            int answer = 0;
            if (newLevel < taskLevel)
            {
                answer = taskTime / newLevel;
                if (answer < 1)
                {
                    answer = 1;
                }
            }
            else
            {
                answer = taskTime * newLevel;
            }

            return answer;
        }
    }
	
	/*
* Class Invariants
* 1) CalculateCost either increase or decreases by 2, based on taskTime
*/    

    class DefaultSkill : Skill
    {
        public DefaultSkill(string newName, string newDescription) :
            base(newName, newDescription)
        {
        }

        public override int CalculateCost(int taskTime, int taskLevel, int empLevel)
        {
            int answer = 0;
            if (empLevel > taskLevel)
            {
                answer = taskTime - 2;
                if (answer < 1)
                {
                    answer = 1;
                }
            }
            else
            {
                answer = taskTime + 2;
            }

            return answer;
        }
    }

/*
* Class Invariants
* 1) Calculate costs either multiplies or divide taskTime by 2
*/    
    class ExtendSkill : DefaultSkill
    {
        public ExtendSkill(string newName, string newDescription) :
            base(newName, newDescription){}

        public override int CalculateCost(int taskTime, int taskLevel, int empLevel)
        {
            int answer = 0;
            int basicCost = base.CalculateCost(taskTime, taskLevel, empLevel);
            if (empLevel > taskLevel)
            {
                if (taskTime % 2 == 1)
                {
                    taskTime += 1;
                }

                answer = taskTime / 2;
                if (answer < 1)
                {
                    answer = 1;
                }
            }
            else
            {
                answer = taskTime * 2;
            }

            return answer;
        }
    }
}