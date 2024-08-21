// Garland Lau
// CPSC 3200-01
// 2/13/24
// P3
// task.cs


using p3;
using System;
using System.Collections.Generic;

namespace P3{
    class Task
    {
        private string _name = "";
        private string _description = "";
        private int _baseTime = 0;
        private bool _isDone = false;
        private Dictionary<Skill, int> _taskSkills = new Dictionary<Skill, int>(); 

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
            set { _taskSkills = value; }
        }
        
        public Task(string newName, string newDescription, int newBaseTime, Dictionary<Skill, int> newTaskSkills )
        { 
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

