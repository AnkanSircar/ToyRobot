# ToyRobot App

This application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units. There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.


## Sample Input & Output 

```
Input
```
- PLACE 0,0,NORTH
- MOVE
- REPORT

```
Output
```
- 0,1,NORTH


```
Input
```
- PLACE 0,0,NORTH
- LEFT
- REPORT
```
Output 
```
- 0,0,WEST


```
Input
```
- PLACE 1,2,EAST
- MOVE
- MOVE
- LEFT
- MOVE
- REPORT

```
Output 
```
- 3,3,NORTH



