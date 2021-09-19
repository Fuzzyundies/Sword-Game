# SwordGame

Passion project to create a rogue-like, mutual executing turn based melee combat.

18-09-2021
Refactored from placeholder/messy code to a better code sample. Previous commit was between design decisions, and wasn't cleaned up properly by myself before trying my hand at creating and then animating a model for the custom animations needed. 
Currently in: 
- Main Menu (with placeholders in options). 
   Nothing exciting, but needs to be done.
- Level Generation 
   From an empty scene (besides a directional light and singular game object, it creates a random tile map, consisting of 4 different types of tiles (able to be set in the DoNotDestroy game object inside the Game Scene. 
   Also, the tiles are not set dimensions, meaning they can be changed/adjusted (as long as a rectangle/square shape).
- Player Spawner 
   Like with the level generation, through code, finds and spawns the player agent on a valid (enabled) tile. 
   This is currently the pausing point, as I am using 0.5f of the capsule collider's height for the spawning location. 
   Once I get a model in there, that bit of code will have to change, and no sense in putting it off.

Currently implemented patterns:
   Object Pool,
   Factories

Next on Pipeline
   Flyweight (materials for tiles),
   Command (multiple implementations),
   Importing my own custom models & animations, and then linking up the players/animation/movement on screen.
