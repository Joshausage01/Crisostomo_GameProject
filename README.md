# Crisostomo_GameProject

A simple text turn-based combat system (with room for improvement).

## Project Overview

This project implements a basic text-based combat system where the player faces multiple enemies in sequence.

## Class Descriptions

### Program.cs
- Contains the `Main` method, which drives the game flow
- `StartUp` method: Handles game exposition and initial setup
- `EnemyGenerator` method: Creates instances of different enemies
- `DisplayEndingScreen` method: Manages the game's conclusion screen

### Unit.cs
- Defines the `Unit` class, which represents both player and enemy characters
- Fields: Characteristics of the units (e.g., health, attack power)
- Constructor: Sets initial parameters for a character unit
- Methods:
  - `Attacking`: Implements attack logic
  - `Heal`: Handles healing mechanics
  - `StatsUp`: Manages leveling up and stat increases

### Gameplay.cs
- Orchestrates the overall game flow
- `MainGameplay` method:
  - Uses a for-loop to cycle through enemy initializations
  - Nested loops and conditionals manage the game's progression
  - Player turn:
    - Choose and execute actions
  - Enemy turn:
    - Randomly select and execute actions
  - Checks for unit death after each turn
    - Continues loop until a unit dies or the player surrenders
    - If player dies: Game Over
    - If enemy dies: Player levels up, new enemy introduced, loop continues

## Final Challenge
- `InitiateGameSummary` method:
  - Displays game summary upon player surrender or victory
  - Shows current status at game end
  - Lists previously defeated enemies

## How to Play
- Choose the actions of your hero
- Win all the battles ahead

## Future Improvements
- Add skills for the player and the enemy
- Add items to be picked up by the user
- Add more dynamic story and adventure
