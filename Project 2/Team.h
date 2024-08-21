// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// Team.h

#ifndef P2_TEAM_H
#define P2_TEAM_H

#include "Task.h"
#include "Employee.h"

#include <string>
#include <vector>
#include <iostream>
using namespace std;

class Team {
private:
    string name;
    vector<Employee*> teamEmployees;
public:
    string getName(){return name;}
    int getNumTeamMembers(){return teamEmployees.size();}
    int estimateTeamTaskTime(Task task);
    void addEmployee(Employee* employee);
    void removeEmployee(string emp_name);

    Team();
    Team(string tName, vector<Employee*> tEmployees);
    ~Team();
    Team(const Team&);
    Team &operator=(const Team&);

};


#endif //P2_TEAM_H
