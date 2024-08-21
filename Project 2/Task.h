// Garland Lau
// CPSC 3200-01
// 1/30/24
// P2
// Task.h

#ifndef P2_TASK_H
#define P2_TASK_H

#include <string>
#include <map>
#include <unordered_map>
#include <iostream>

using namespace std;


class Task {
private:
    string name;
    string description;
    int baseTimeHours;
    bool isDone;
    unordered_map<string, int> taskSkills;
public:
    string getName() const {return name;}
    string getDescription(){return description;}
    string setDescription(string newDescript){description = newDescript;}
    unordered_map <string, int> getTaskSkills() const {return taskSkills;}
    int getBaseTimeHours() const {return baseTimeHours;}
    void setTaskAsDone(){isDone = true;}

    Task();
    Task(string newName, string newDescript, int newBaseTime, unordered_map<string, int> newTaskSkills);
    ~Task();
    Task(const Task&);
    Task &operator=(const Task&);




};


#endif //P2_TASK_H
