// Garland Lau
// CPSC 3200-01
// 2/13/24
// P3
// employee.cs


using p3;
using System;
using System.Collections.Generic;

namespace P3
{
    class Employee
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
            set { _empSkills = value; }
        }

        public Employee(string newName, int newWorkTime, Dictionary<Skill, int> newEmpSkills)
		{
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