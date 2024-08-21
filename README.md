# Object-Oriented-Design
An Object Oriented Design class

# Project 1
Class Specifications
Create two classes, Task and Employee. You may create helper classes as needed, but these two are required.

Task
A Task has the following:

A name, which can only be set when the task is created.
A description, which can be changed at any time.
A base amount of time that it will take to complete the task that can only be set when the task is created.
An indicator for whether the task is done or not. A task defaults to not done.
Zero or more skills involved in completing the task. For each skill involved, the task should have an associated difficulty level. For example, the task "P1" could have a difficulty level of 2 for the skill "C# class creation" and a difficulty level of 4 for the skill "MSTest". The skills and related difficulty levels can only be set when the task is created.
Employee
An Employee has the following:

A name, which can only be set when the employee is created.
A number of hours that they've spent working on tasks.
Zero or more skills. For each skill, the employee should have an associated proficiency level. For example, one specific employee might be at level 6 in the skill "Grocery bagging" but only level 2 in "Cash register operation". The client should be able to optionally specify an initial set of skills and proficiency levels. If the client does not specify, employees start out with no skills.
A method for estimating the amount of time it would take for the employee to complete a given task. The only restriction is that the amount of time should be based on the task's difficulty levels vs. the employee's proficiency levels for the associated skills, otherwise it is up to you to come up with your own formula. This method only gives an estimate; it should not change any state.
A method for doing a given task.
A task cannot be done twice.
The employee's number of hours worked should go up by the number of hours it took the employee to perform the task.
The employee should gain proficiency levels based on which skills were involved in completing the task. The more difficult it was for the employee relative to their existing proficiency level, the more proficiency they should gain.
Contract Documentation
Write contracts for Task, Employee, and any other classes you wrote. Contracts must include:

A class invariant for every fact that holds true for the lifetime of an instance of the class. You must have at least three class invariants combined across your classes.
A precondition for any assumption you make about inputs to a method. You must have at least two preconditions combined across your classes.
A postcondition stating the guaranteed outcomes of a method. You must have at least two postconditions combined across your classes.
Invariants, preconditions, and postconditions must all be written as true/false statements about public fields/getters or method parameters (i.e. they can't be about anything private, purely local to a method, or outside of the class). Class invariants must be written just before your class declaration. Preconditions and postconditions must be written immediately before their respective method declarations.

Unit Testing
Using MSTest, write a suite of unit tests that achieves 100% branch coverage on Task, Employee, and any other classes you wrote. These tests are your replacement for a main() function for P1.

# Project 2
C++ Conversion
Re-write your existing classes (but not the tests) from P1 in C++. You may use any STL containersLinks to an external site. you like in your Task and Employee classes. As noted below, you need to support deep copying for these two classes with the copy constructor and copy assignment operator. If you allocate heap memory in either class, make sure you are also deleting it.

Note: the biggest challenge in this part is that you no longer have C#'s autopilot when it comes to pointers and references. While classes are effectively passed by reference in C#, you have to consciously choose whether every parameter in every method will take a value/copy, a reference, or a pointer. Similarly, you no longer have C#'s garbage collector, meaning you need to decide whether each member variable is going to be allocated within the class (non-pointer) or in its own, independent memory block (pointer).

Class Specifications
Create two new classes, Team and Company. You may create helper classes as needed, but these two are required.

Team
A Team has an immutable name and a variable number of employees (i.e. the client should be able to dynamically decide to assign any number of employees to a team at runtime). In addition, it should have methods that do the following:

Add a given employee to the team.
Remove an employee with a given name from the team.
Produce an estimate of the amount of time it would take to complete a given task. The signature should be the same as the one you wrote for Employee, but its implementation should rely on the estimates given by employees added to the team.
A Team is not responsible for managing the lifetimes of its Employees. You must use pointers to Employees, not the non-pointer type (i.e. Employee*, not Employee). 

You may use STL containers in this class, but beware - you may run into memory management issues if you aren't careful with them.

Company
A Company has an immutable name, a variable number of employees, and a variable number of teams (i.e. the client should be able to dynamically decide to hire any number of employees or create any number of teams at runtime). It should also have methods for the following:

Registering a new employee with the company.
Firing an existing employee from the company.
Creating a new team.
Canceling (destroying) an existing team.
Get a reference/pointer (you choose which) to a team by name.
Get a reference/pointer (you choose which) to an employee by name.
A Company is responsible for managing the lifetimes of its Teams and Employees. In other words, if you destroy a Company, it needs to destroy its Teams and Employees.

You may use STL containers in this class, but beware - you may run into memory management issues if you aren't careful with them.

Copy Operations
All of your classes should support deep copying. Write your own copy constructors and copy assignment operators as needed.

Contract Documentation
Continue to document any class invariants, preconditions, and postconditions necessary in your classes. If you change the behavior of your classes from P1, you must update their contracts.

Demo Programs
Write three separate main() functions in three separate files - demo1.cpp, demo2.cpp, and demo3.cpp. Each one should show off one scenario involving a Company, multiple Teams, and the management of Employees across teams. At least one demo should also show how to get estimates from teams.

# Project 3
C# Conversion
Re-write your Team and Company classes in C#. You do not need port your destructors or copy assignment operators. You may choose whether to write copy constructors or give each class a method called DeepClone() that creates and returns a deep copy of the current object. If you made any changes to your Task or Employee classes for P2 (other than memory management, which C# will do for you), also implement them in C#. You do not need to re-write your demo code from P2.

Class Specifications
Skill + Subclasses
Create a class called Skill that has:
an immutable name,
an immutable description,
GetHashCode() and Equals() implementations,
and a method called CalculateCost() which takes in a base cost and two skill levels (the tasks' difficulty and the employee's proficiency) and produces a cost.
Create at least three subclasses of Skill, each with their own implementation of CalculateCost().
At least one but not all of the subclasses should have some element of randomness to them. Use dependency injection to give a random number generator to this/these subclass(es).
At least one but not all of the subclasses should contain or extend one of the other subclasses and use the other's CalculateCost() as part of its CalculateCost().

Contract Documentation
Continue to document any class invariants, preconditions, and postconditions necessary in your classes. If you change the behavior of your classes from P2, you must update their contracts.

# Project 4
Class Specifications
IOrgChange
Create an interface called IOrgChange. It should have a single method named "Apply" that takes a Company as a parameter.

HireOperation
Create a class called HireOperation that implements IOrgChange and contains a person's name. Its Apply method should make the Company hire a new Employee with that name and random starting skills.

CreateTeamOperation
Create a class called CreateTeamOperation that implements IOrgChange and contains a name for a team. Its Apply method should make the Company create a new team with the given name.

TransferOperation
Create a class called TransferOperation that implements IOrgChange and contains the name of an employee plus a nullable name for a team. Its Apply method should make the Company remove the Employee from their old Team and assign the employee to the new Team. If the new Team name is null, you only need to unassign the Employee from their old Team.

Driver Code
Write a program that:

Creates at least three Skills (but preferably more), at least one for each difficulty curve.
Creates at least three Tasks (but preferably more), each with at least one Skill (but preferably more), making sure to use each Skill from the previous point at least once.
Creates an empty Company.
Reads a file. The name of the file will be in args[0] (args being the parameter given to Main() or a global variable if you don't have a Main()).
Creates a List<IOrgChange> and adds one instance of IOrgChange for each line in the file it read in.
For each IOrgChange:
Applies the IOrgChange to the Company.
Prints out each Team's cost estimate for each Task.
