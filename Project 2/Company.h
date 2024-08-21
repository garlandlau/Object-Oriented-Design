// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// Company.h

#ifndef P2_COMPANY_H
#define P2_COMPANY_H

#include "Task.h"
#include "Employee.h"
#include "Team.h"

#include <vector>

class Company {
private:
    string name;
    vector<Employee*> companyEmployees;
    vector<vector<Team*>> companyTeams;
public:

    void hireEmployee(Employee* emp);
    void fireEmployee(Employee* emp);
    void buildTeam(string tName, vector<Employee*> tEmployees);
    void destroyTeam(string tName);
    Employee* returnEmployee(string& eName);
    Team* returnTeam(string& tName);


    Company();
    Company(string cName, vector<Employee*> cEmployees, vector<vector<Team*>> cTeams);
    ~Company();
    Company(const Company&);
    Company &operator=(const Company&);

};


#endif //P2_COMPANY_H
