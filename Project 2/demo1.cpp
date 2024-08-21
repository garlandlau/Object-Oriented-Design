// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// demo1.cpp

// Team estimateTeamTaskTime is called
// Employee hireEmployee() and fireEmployee() are called


#include "Task.h"
#include "Employee.h"
#include "Team.h"
#include "Company.h"

#include <iostream>
#include <unordered_map>
#include <vector>

using namespace std;

int main(){
    Task task1("Build website", "Design and implement a website", 10,
               {{"HTML", 5},{"CSS", 5}, {"JAVASCRIPT", 5}});
    Task task2("Build videogame", "Design and implement a videogame", 20,
               {{"C++", 6},{"C#", 8},{"OPENGL", 10}});

    Employee emp1("Alice", 10, {{"C++", 10}, {"C#", 6}});
    Employee emp2("Bob", 0, {});
    Employee emp3("Charlie", 20, {{"OPENGL", 1}, {"C#", 6}});
    Employee emp4("David", 20,
                  {{"HTML", 10}, {"CSS", 10}, {"JAVASCRIPT", 1}});

    Employee* empPtr1 = &emp1;
    Employee* empPtr2 = &emp2;
    Employee* empPtr3 = &emp3;
    Employee* empPtr4 = &emp1;

    Team team1("Web Team", {});
    team1.addEmployee(empPtr2);
    team1.addEmployee(empPtr4);
    int webTeamTime = team1.estimateTeamTaskTime(task1);
    cout << "Time for Web Team(Team) to Build website(Task): " << webTeamTime << endl;

    Company company1("Microsoft", {}, {});
    company1.hireEmployee(empPtr1);
    company1.hireEmployee(empPtr2);
    company1.hireEmployee(empPtr3);
    company1.hireEmployee(empPtr4);
    
    company1.fireEmployee(empPtr2);




    return 0;
}