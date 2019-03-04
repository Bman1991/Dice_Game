Dice Game

Description: 
The Dice Game is a simple game of rolling dice and seeing what you roll. Using Unity game engine, Maya, and C# to create a solution of capturing rolled numbers. 

A classmate had a similar game where he used the orientation of the dice to capture rolls; problem was that this only works for 6-sided dice and not for dice that have more sides or are weirdly shaped. So instead, I took on the challenge of finding an alternative way to capture the rolled numbers. 

The solution I found used raycasting to shoot a line from the center of the dice straight up; whatever number collides with the raycast, is the rolled number. This way it doesn't matter too much on how many sides a die has, a number can be captured without writing a complicated function to determine die orientation to capture the roll. 

Pictures are provided showing what the game looks like and how it works. 

How it works:
There are 3 dice with the dice script attach and a dice manager. At start the dice will roll until they stop. Once they stop rolling, the dice script is instructed to shoot a raycast straight up to capture the rolled number that it collides with. Once the roll is captured, dice calls the dice manager and checks in it's number. After all dice are checked in, the dice manager will add all the rolled numbers together and displays the total current roll and the total rolls during the game. 