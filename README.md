# ToyRobot Simulator App

This application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units. There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.

The application should be able to read in any one of the following commands:
- PLACE X,Y,F
- MOVE
- LEFT
- RIGHT
- REPORT

## Getting Started 

The solution has been built as dot net core console application using C# as programming language. There is a test project ToyRobotApp.Tests which contains unit tests to cover the core functionality of this application. 

### Prerequisites

To get this project up and running on your local machine, please make sure you have .NET SDK installed on your machine. You can follow the following link to have it all installed. 
- https://www.microsoft.com/net/learn/get-started 

Also you can use VS2017 or a light weight version of dot net editor such as VSCode to keep working on this project. 

### Running the app

To run the app, simply download the project, open in VS2017 and press F5. Once the console app is up and running, follow the instructions on the screen. 
This is a console app where you can run a sequence of valid commands, if no error, you can carry on and at any point of time, you need to know the current position of the robot, you can run the REPORT command. 
Please also have a look at the Sample input/output section to get an idea of a list of valid commands. 

### Sample Input & Output 

```
Input
```
PLACE 0,0,NORTH
MOVE
REPORT

```
Output
```
0,1,NORTH


```
Input
```
PLACE 0,0,NORTH
LEFT
REPORT
```
Output 
```
0,0,WEST


```
Input
```
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT

```
Output 
```
3,3,NORTH

### Running the tests

To run the tests simply open the solution in Visual studio and run all the tests from Test Explorer (TEST > RUN > ALL TESTS).

Alternatively, you can install  "dot net core test explorer" extension to run all tests from VSCode as well. 
- https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer

## Contributing

Please read [CONTRIBUTING.md](https://github.com/AnkanSircar/ToyRobotSimulator/blob/master/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.





