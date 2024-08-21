// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// Team.cpp

#include "Team.h"
#include <iostream>

Team::Team(){
    name = "No team name";
    teamEmployees =  {};
}


Team::Team(string tName, vector<Employee*> tEmployees){
    name = tName;
    teamEmployees = tEmployees;
}

Team::~Team(){
    for(auto entry : teamEmployees){
        delete entry;
    }
}

Team::Team(const Team& other){
    name = other.name;
    for(const auto& entry : other.teamEmployees){
        teamEmployees.push_back(new Employee(*entry))
    }
}

Team &Team::operator=(const Team& other) {
    if (this == &other) {
        return this;
    }
    name = other.name();
    for (auto entry: teamEmployees) {
        delete entry;
    }
    teamEmployees.clear();

    for (const auto &entry: other.teamEmployees) {
        teamEmployees.push_back(new Employee(*entry));
    }

    return *this;
}

/* Pre-Conditions: task is valid. taskSkills is not empty
 *  -Employee is valid. empSkills is not empty
 *   -Team is valid. teamEmployees is not empty
 * Post-Conditions:
 *  -calculates avg of individual employees doing a task
 *  -returns a positve number of hours
 */

int Team::estimateTeamTaskTime(Task task){
    int totalTime = 0;
    int individualTime;
    int avgTime;
    int numEmployees = teamEmployees.size();
    for(const auto& entry : teamEmployees){
        individualTime = entry->estimateTaskTime(task);
        totalTime += individualTime;
    }
    avgTime = totalTime / numEmployees;
    return avgTime;
};

/* Pre-Conditions:
 *  -Employee is valid. Employee is not already in Team
 *  -Team is valid
 * Post-Conditions:
 *  -teamEmployees is not empty. Has 1+ members
 */

void Team::addEmployee(Employee* emp){
    teamEmployees.push_back(emp);
}

/* Pre-Conditions:
 *  -Employee is valid. Employee is in Team
 *  -Team is valid. teamEmployees is not empty
 * Post-Conditions:
 *  -teamEmployees has 1 less member. Can by empty
 */
void Team::removeEmployee(string emp_name){
    for(auto it = teamEmployees.begin(); it != teamEmployees.end(); it++){
        if((*it)->getName() == emp_name){
            delete *it;
            it = teamEmployees.erase(it);
            it--;
        }
    }
}