### CS 410 S24 Assignment 2

Dot product - Ryan Helms  
- Assets\UnityTechnologies\3DBeginnerComplete\Scripts/FacePlayer.cs - 
The first Gargoyle now turns to face the player when the player is in range. 
This was done using the dot product and cross product between the Gargoyle and 
player vectors.

Linear interpolation - Sadie Shinault
- Assets/lerp_bath_ghost.cs - The ghost in the bathtub turns to face the player
- Assets/garg_lerp.cs - Gargoyle models scale up and down

Particle effect/trigger - Lochlan Scharpf
- Assets/UnityTechnologies/3DBeginnerComplete/Scripts/ParticleTrigger.cs
- The gargoyle cries when you leave its radius.

Sound effect/trigger - Ethan Reinhart
- Assets/UnityTechnologies/3DBeginnerComplete/Audio/crying.mp3 and Assets/UnityTechnologies/3DBeginnerComplete/Scripts/CryingScript.cs
- The crying audio increases in volume the further you are from a ghost (max 5 blocks away)
- Becomes quieter and quieter as ghost approaches, simulates fear / neccesity to be quiet to avoid being caught
- Obtains positions of all Ghosts and Player and distance between the two and modifies volume based on said distance
