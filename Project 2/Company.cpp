// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// Company.cpp

#include "Company.h"

#include <iostream>


using namespace std;

Company::Company(){
    name = "no name";
    companyEmployees = {};
    companyTeams = {};
}

Company::Company(string cName, vector<Employee*> cEmployees = {}, vector<vector<Team*>> cTeams = {}){
    name = cName;
    companyEmployees = cEmployees;
    companyTeams = cTeams;
}

Company::~Company(){
    for(auto& teamVector : companyTeams){
        for(auto team : teamVector){
            delete team;
        }
    }

    for(auto employee: companyEmployees){
        delete employee;
    }
}

Company::Company(const Company& other){
    name = other.name;

    // Copy Employees
    for(const auto& emp : other.companyEmployees){
        companyEmployees.push_back(new Employee(*emp));
    }

    //Copy Teams
    for(const auto& teamVector : other.companyTeams){
        vector<Team*> newTeamVector;
        for(const auto& team : teamVector){
            newTeamVector.push_back(new Team(*team));
        }
        companyTeams.push_back(newTeamVector);
    }
}

Company &Company::operator=(const Company& other){
    name = other.name;
    if(this == &other){
        return *this;
    }

    for(auto& teamVector: companyTeams){
        for(auto team: teamVector){
            delete team;
        }
    }

    for(auto employee : companyEmployees){
        delete employee;
    }

    companyTeams.clear();
    companyEmployees.clear();

    //Copy employees
    for(const auto& emp : other.companyEmployees){
        companyEmployees.push_back(new Employee(*emp));
    }

    //Copy teams
    for(const auto& teamVector : other.companyTeams){
        vector<Team*> newTeamVector;
        for(const auto& team : teamVector){
            newTeamVector.push_back(new Team(*team));
            companyTeams.push_back(newTeamVector);
        }
    }

    return *this;
}

/* Pre-Conditions:
 *  -Employee is valid. Employee is not already in Company
 *  -Company is valid
 * Post-Conditions:
 *  -companyEmployees is not empty. Has 1+ members
 */
void Company::hireEmployee(Employee* emp){
    companyEmployees.push_back(emp);
}

/* Pre-Conditions:
 *  -Employee is valid. Employee is in Company
 *  -Company is valid
 * Post-Conditions:
 *  -companyEmployees has 1 less member. Can be empty
 *  -employee is not in any teams
 */
void Company::fireEmployee(Employee* emp){
    string emp_Name = emp->getName();

    // Remove from teams
    for(auto& teamVector : companyTeams){
        for(auto team : teamVector){
            team->removeEmployee(emp_Name);
        }
    }

    // Remove from company
    for(auto it = companyEmployees.begin(); it != companyEmployees.end(); it++){
        if((*it)->getName() == emp_Name){
            delete *it;
            it = companyEmployees.erase(it);
            it--;
        }
    }

}

/* Pre-Conditions:
 *  -<Employee*> tEmployees is valid and not empty
 *  -Team is not already in company
 * Post-Conditions:
 *  -teamEmployees is not empty. Has 1+ members
 */
void Company::buildTeam(string tName, vector<Employee*> tEmployees){
    companyTeams.push_back(vector<Team*>{new Team(tName, tEmployees)});
}

/* Pre-Conditions:
 *  -Team tEmployees is valid, not empty, and part of Company
 * Post-Conditions:
 *  -teamEmployees has 0 members
 *  Team is removed from vector<vector*>> companyTeams
 */
void Company::destroyTeam(string tName){
    for(auto it = companyTeams.begin(); it != companyTeams.end(); it++){
        if(!it->empty() && (*it)[0]->getName() == tName) {
            for (auto team: *it) {
                delete team;
            }
            it = companyTeams.erase(it);
            it--;
            break;
        }
    }
}

/* Pre-Conditions:
 *  -string employee Name is valid and in company
 * Post-Conditions:
 *  -pointer to employee returned
 *  -if employee not in company, return nullptr;
 */
Employee* Company::returnEmployee(string& eName){
    for(auto& emp : companyEmployees){
        if(emp->getName() == eName){
            return emp;
        }
    }
    return nullptr;
}

/* Pre-Conditions:
 *  -string team Name is valid and in company
 * Post-Conditions:
 *  -pointer to team returned
 *  -if team not in company, return nullptr;
 */
Team* Company::returnTeam(string& tName){
    for(auto& teamVector : companyTeams){
        if(!teamVector.empty() && teamVector[0]->getName() == tName){
            return teamVector[0];
        }
    }
    return nullptr;
}
