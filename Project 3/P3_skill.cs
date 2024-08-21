// Garland Lau
// CPSC 3200-01
// 2/13/24
// P3
// skill.cs


using p3;
using System;
using System.Collections.Generic;

namespace p3{
    class Skill{
        private string _name = "";
        private string _description = "";

        public string name {
            get {return _name;} 
            set {_name = value;}
        }
        
        public string description {
            get {return _description;} 
            set {_description = value;}
        }

        public Skill(string newName, string newDescription){
            name = newName;
            description = newDescription;
        }


        public virtual int CalculateCost(int taskTime, int taskLevel, int empLevel){
            int answer = 0;
            if(empLevel > taskLevel){
                if(taskTime % 2 == 1){
                    taskTime += 1;
                }
                answer = taskTime / 2;
            }else if(empLevel < taskLevel){
                answer = taskTime * 2;
            }else{
                answer = taskTime;
            }

            return answer;
        } 

        
        public override int GetHashCode(){
            HashCode hash = new HashCode();
            hash.Add(name);
            hash.Add(description);
            return hash.ToHashCode();
        }

        public override bool Equals(Skill other){
            if (other != null && other.name == name && other.description == description){
                return true;
            }
            return false;
        }

    }

    class RandomSkill : Skill{
        private Random _random;

        public RandomSkill(string newName, string newDescription, Random random) : 
            base(newName, newDescription){
                _random = random;
            }

        public override int CalculateCost(int taskTime, int taskLevel, int empLevel){
            int newLevel = _random.Next(1, empLevel + taskLevel);
            int answer = 0;
            if(newLevel < taskLevel){
                answer = taskTime / newLevel;
				if(answer < 1){
					answer = 1;
				}
            }else{
                answer = taskTime * newLevel;
            }
			return answer;
        }
    }

    class DefaultSkill : Skill{
        public DefaultSkill(string newName, string newDescription) : 
            base(newName, newDescription){}
        
        public override int CalculateCost(int taskTime, int taskLevel, int empLevel){
            int answer = 0;
            if(empLevel > taskLevel){
                answer = taskTime - 2;
                if (answer < 1){
                    answer = 1;
                }
            }else{
                answer = taskTime + 2;
            }

            return answer;
        }
    }

    // (Skill - 2) / 2 || (Skill + 2) * 2
    // taskTime is always >= 1
    class ExtendSkill : DefaultSkill{
        public ExtendSkill(string newName, string newDescription) : 
            base(newName, newDescription){}
        public override int CalculateCost(int taskTime, int taskLevel, int empLevel){
            int answer = 0;
            int basicCost = base.CalculateCost(taskTime, taskLevel, empLevel);
            if(empLevel > taskLevel){
                if(taskTime % 2 == 1){
                    taskTime += 1;
                }
                answer = taskTime / 2;
                if(answer < 1){
                    answer = 1;
                }
            }else{
                answer = taskTime * 2;
            }
			return answer;
        }
    }
}