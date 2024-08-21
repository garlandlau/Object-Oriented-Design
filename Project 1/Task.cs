// Garland Lau
// CPSC 3200-01
// 1/14/24
// P1
// Task.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace P1
{
    class Task
    {
    /* Class Invariants
    * 1) Task Names should be unique and not empty
    * 2) The taskBaseTimeHours should not be negative or zero
    * 3) The _taskNeedSkills should not be null
    * 4) isDone is always initiated to false
    * Implementation Invariant
    * 1) _taskNeedSkills requires a task to have a skill 0 or 1 times (no
    duplicates)
    * 2) the skill level should be non-negative
    * Interface Invariant
    * 1) A default constructor is called when not enough info is provided for
    Task
    * constructor. A basic name, description, and empty dictionary is
    provided
    */
        private string _taskName;
        private string _taskDescription;
        private double _taskBaseTimeHours;
        private bool _isDone = false;
        private Dictionary<string, int> _taskNeedSkills;
        public string taskName
        {
            get { return _taskName; }
            private set { _taskName = value; }
        }
        public string taskDescription
        {
            get { return _taskDescription; }
            private set { _taskDescription = value; }
        }
        public double taskBaseTimeHours
        {
            get { return _taskBaseTimeHours; }
            private set { _taskBaseTimeHours = value; }
        }
        public bool isDone
        {
            get { return _isDone; }
            private set { _isDone = value; }
        }
        public Dictionary<string, int> taskNeedSkills
        {
            get { return _taskNeedSkills; }
            private set { _taskNeedSkills = value; }
        }
        // Post-Condition: isDone will be true
        public void setAsDone()
        {
            isDone = true;
        }
        // Post-Condition: description will be set
        public void setDescription (string description)
        {
            taskDescription = description;
        }
        public Task()
        {
            taskName = "Basic task";
            taskDescription = "Default description";
            taskBaseTimeHours = 0.0;
            isDone = false;
            taskNeedSkills = new Dictionary<string, int>();
        }
        public Task(string tName, string tDescription, double tBaseTImeHours, Dictionary<string, int> tNeedSkills )
        {
            taskName = tName;
            taskDescription = tDescription;
            taskBaseTimeHours = tBaseTImeHours;
            isDone = false;
            taskNeedSkills = tNeedSkills;
        }
    }
}
