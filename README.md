# Object-Oriented-Design
An Object Oriented Design class

# Project 1
Create two classes, Task and Employee and use Unit Testing.

Task has the following:
- A name, which can only be set when the task is created.
- A description, which can be changed at any time.
- A base amount of time that it will take to complete the task set when the task is created.
- An indicator for whether the task is done or not. A task defaults to not done.
- Zero or more skills involved in completing the task. For each skill, the task should have a difficulty level.
- - Ex: Task "P1" could have a difficulty level of 2 for the skill "C# class creation" .
- - The skills and related difficulty levels can only be set when the task is created.
- A task cannot be done twice.

Employee has the following:
- A name, which can only be set when the employee is created.
- A number of hours that they've spent working on tasks.
- Zero or more skills. For each skill, the employee should have an associated proficiency level.
- - Ex: one employee might be at level 6 in the skill "Grocery bagging" but only level 2 in "Cash register operation".
- - If the client does not specify an initial set of skills and proficiency levels, employees start out with no skills.
- A method for estimating the amount of time it would take for the employee to complete a given task. 
- The employee's number of hours worked should go up by the number of hours it took the employee to perform the task.
- The employee should gain proficiency levels based on which skills were involved in completing the task.

# Project 2
Re-write Task and Employee from P1 in C++. 
- Support deep copying for these two classes with the copy constructor and copy assignment operator
- If you allocate heap memory in either class, make sure you are also deleting it.

Create two new classes, Team and Company and write demo programs for scenarios involving all 4 classes. 

Team has the following:
- An immutable name and a variable number of employees 
- Add a given employee to the team.
- Remove an employee with a given name from the team.
- Produce an estimate of the amount of time it would take to complete a given task. 
- A Team uses pointers to Employees, not the non-pointer type (i.e. Employee*, not Employee). 

Company
- An immutable name, a variable number of employees, and a variable number of teams 
- Registering a new employee with the company.
- Firing an existing employee from the company.
- Creating a new team.
- Canceling (destroying) an existing team.
- Get a reference/pointer (you choose which) to a team by name.
- Get a reference/pointer (you choose which) to an employee by name.
- A Company manages the lifetimes of its Teams and Employees. If you destroy a Company, it needs to destroy its Teams and Employees.

Copy Operations
- All of your classes should support deep copying. Write your own copy constructors and copy assignment operators as needed.

# Project 3
Re-write the Team and Company classes from P2 in C#

Class Specifications
- Skill + Subclasses

Create a class called Skill that has:
- an immutable name,
- an immutable description,
- GetHashCode() and Equals() implementations
- CalculateCost() which takes in a base cost and two skill levels (the tasks' difficulty and the employee's proficiency) and produces a cost.

Create at least three subclasses of Skill, each with their own implementation of CalculateCost().
- At least one subclass should have some element of randomness to them. Use dependency injection to give a random number generator to this subclass.
- At least one of the subclasses should contain or extend one of the other subclasses and use the other's CalculateCost() as part of its CalculateCost().

# Project 4
- Reuse Employee, Task, Team, Company, and Skill classes in C#
   
IOrgChange 
- have a single method named "Apply" that takes a Company as a parameter.

HireOperation
- implements IOrgChange and contains a person's name
- its Apply method should make the Company hire a new Employee with that name and random starting skills.

CreateTeamOperation
- implements IOrgChange and contains a name for a team
- its Apply method should make the Company create a new team with the given name.

TransferOperation
- implements IOrgChange and contains the name of an employee plus a nullable name for a team
- its Apply method should make the Company remove the Employee from their old Team and assign the employee to the new Team
- - if the new Team name is null, you only need to unassign the Employee from their old Team.

Driver Code. Write a program that:
- Creates at least three Skills (but preferably more), at least one for each difficulty curve.
- Creates at least three Tasks (but preferably more), each with at least one Skill, making sure to use each Skill from the previous point at least once.
- Creates an empty Company.
- Reads a file. The name of the file will be in args[0] (args being the parameter given to Main() or a global variable if you don't have a Main()).
- Creates a List<IOrgChange> and adds one instance of IOrgChange for each line in the file it read in.
- - For each IOrgChange:
- - - Applies the IOrgChange to the Company.
- - - Prints out each Team's cost estimate for each Task.
