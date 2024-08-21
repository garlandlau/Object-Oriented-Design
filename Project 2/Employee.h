// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// Employee.h


#ifndef P2_EMPLOYEE_H
#define P2_EMPLOYEE_H

#include "Task.h"


#include <string>
#include <map>
#include <unordered_map>

using namespace std;

class Employee {
private:
    string name;
    int totalWorkHours;
    unordered_map<string, int> empSkills;
public:
    string getName() const {return name;}
    int getTotalWorkHrs() { return totalWorkHours;}
    int get_emp_sk_lvl(string sName){ return empSkills[sName];}
    int setTotalWorkHrs(int newTotalHrs) {totalWorkHours = newTotalHrs;}

    unordered_map<string, int> getEmpSkills(){return empSkills;}
    // map<string, int setEmpSkills(string sName, int sIncrease){};

    int estimateTaskTime(const Task&);
    void completeTask(Task);

    Employee();
    Employee(string newName, int newTotalHrs, unordered_map <string, int> newEmpSkills);
    ~Employee();
    Employee(const Employee&);
    Employee &operator=(const Employee&);


};


#endif //P2_EMPLOYEE_H
