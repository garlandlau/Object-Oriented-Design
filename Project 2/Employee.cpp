// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// Employee.cpp

/* Class Invariants
 * - Employee Names should be unique and not empty
 * - empWorkHours should not be negative
 * - empHasSkills should not be null
 * - empHasSkills requires an employee to have a skill 0 or 1 times (no duplicates)
 * - the skill level should be non-negative
*/

#include "Employee.h"
#include "Task.h"
#include <map>
#include <unordered_map>
#include <iostream>

using namespace std;

Employee::Employee(){
    name = "No Name";
    totalWorkHours = 0;
    empSkills = {};
}

Employee::Employee(string newName, int newTotalHrs, unordered_map <string, int> newEmpSkills){
    name = newName;
    totalWorkHours = newTotalHrs;
    empSkills = newEmpSkills;
}

Employee::~Employee(){
    name = "";
    totalWorkHours = 0;
    empSkills = {};
}

Employee::Employee(const Employee& other){
    name = other.name;
    totalWorkHours = other.totalWorkHours;
    empSkills = other.empSkills;
}

Employee &Employee::operator=(const Employee& other){
    if(this == &other){
        return *this;
    }
    name = other.name;
    totalWorkHours = other.totalWorkHours;
    empSkills = other.empSkills;
    return *this;
}

/* Pre-conditions: task is valid. taskSkills is not empty
 * Post-Conditions: returns answer >= 1. Numbers will always round up (o.5 -> 1)
 */

int Employee::estimateTaskTime(const Task& task) {
    int totalSkillDiff = 0;
    int taskTime = task.getBaseTimeHours();
    int answer;

    for(const auto& entry : task.getTaskSkills()) {
        string skill_name = entry.first;
        int task_sk_level = entry.second;

        if (empSkills.find(skill_name) != empSkills.end()) {
            int emp_sk_level = get_emp_sk_lvl(skill_name);
            int tempSkillDiff = 0;
            tempSkillDiff = emp_sk_level - task_sk_level;
            totalSkillDiff += tempSkillDiff;
        }
    }

    // Task time will always be rounded up
    if(totalSkillDiff > 0) {
        if(taskTime % 2 == 1) {
            taskTime += 1;
        }
        answer = taskTime / 2;
    }else if(totalSkillDiff < 0) {
        answer = taskTime * 2;
    }else {
        answer = taskTime;
    }
    return answer;
}

/* Pre-Conditions: task is valid. taskSkills is not empty
 *  -Employee is valid. empSkills is not empty
 * Post-Conditions: task will be done.
 *  -empSkills will increase. If skill from task not in empSkills,
 *      taskSkill will be inserted into empSKills
 *  -skill level increases based on difference between task and employee
 *      levels. If employee is already proficent, increases by 1.
 *      Otherwise increase by half the difference between task and employee levels
 */

void Employee::completeTask(Task task) {
    int addHours = estimateTaskTime(task);
    totalWorkHours += addHours;
    task.setTaskAsDone();

    for(const auto& entry: task.getTaskSkills()){
        string skill_name = entry.first;
        int task_sk_lvl = entry.second;

        int skill_inc;
        if(empSkills.find(skill_name) != empSkills.end()){
            int emp_sk_lvl = get_emp_sk_lvl(skill_name);
            int skillDiff = emp_sk_lvl - task_sk_lvl;

            if(skillDiff >= 0){
                skill_inc = 1;
            }else{
                if(skillDiff % 2 == 1){
                    skillDiff += 1;
                }
                skillDiff = skillDiff / 2;
            }
            skill_inc += emp_sk_lvl;
            empSkills[skill_name] = skill_inc;
        }else{
            int skillDiff = task_sk_lvl;
            skill_inc;
            if (skillDiff % 2 == 1){
                skillDiff += 1;
            }
            skill_inc = skillDiff / 2;
            empSkills[skill_name] = skill_inc;
        }
    }
}