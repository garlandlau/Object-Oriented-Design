// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// Task.cpp

/* Class Invariants:
 *  -Task Names should be unique and not empty
 *  -taskBaseTimeHours should not be negative or zero
 *  -taskSkills should not be null
 *  -isDone is always initiated to false
 *  -taskSkills should have unique taskNames, with levels 1+
 */

#include "Task.h"
using namespace std;

Task::Task(){
    name = "Basic Task";
    description = "Default description";
    baseTimeHours = 1;
    isDone = false;
    taskSkills = {};
}

Task::Task(string newName, string newDescript, int newBaseTime, unordered_map<string, int> newTaskSkills){
    name = newName;
    description = newDescript;
    baseTimeHours = newBaseTime;
    isDone = false;
    taskSkills = newTaskSkills;
}

Task::~Task(){
    name = "";
    description = "";
    baseTimeHours = 0;
    isDone = true;
    taskSkills = {};
}

Task::Task(const Task& other){
    name = other.name;
    description = other.description;
    baseTimeHours = other.baseTimeHours;
    taskSkills = other.taskSkills;
}

Task &Task::operator=(const Task& other){
    if(this == &other){
        return *this;
    }
    name = other.name;
    description = other.description;
    baseTimeHours = other.baseTimeHours;
    taskSkills = other.taskSkills;
    return *this;
}



