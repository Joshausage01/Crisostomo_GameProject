# Crisostomo_GameProject
 Text turn based combat system (still have many rooms for improvement) READ THIS IN CODE!!!


## Project Overview
This project implements a basic text-based combat system where the player faces multiple enemies in sequence.

###Class descriptions:
[Program.cs]
  -Main method
  -StartUp method where the game exposition is located
  -EnemyGenerator method where the different instances of enemies listed
  -DisplayEndingScreen method where the end screen of the game is coded in

[Unit.cs]
  -It is where the fields of the Units are coded in that acts as the characteristics of the units
  -Unit constructor is what sets the paramaters for a character unit
  -There are methods here which acts as the actions of the units
     -Attacking method where the attack logic of the units is in
     -Heal method where the heal logic of the units is in
     -StatsUp method is where the leveling up or gaining stats logic for the units is coded

[Gameplay.cs]
  -It is where all the flow of the game is constructed
  -MainGameplay method
     -For-loop is for the cycle of the initializations of enemies
     -Nest loops and if-else for the whole run of the game
     -(Player turn)
        -choose actions
        -execute actions
     -(Enemy turn)
        -randomly choose actions
        -execute actions
     -(Identify if any of the units is dead)
        -Keep looping until a unit is dead or the player gave up
        -if a unit is dead, identify if its player or enemy
           -if player dead, GAME OVER!
           -if enemy dead, player level up then introduce new enemy then loop again.

FINALS_CHALLENGE:
  -InitiateGameSummary method 
     -Prompts the game summary when player surrendered or the player won against all enemies
     -Prompts the current status before surrendering or winning the game
     -Prompts the name of the previously slain enemies
