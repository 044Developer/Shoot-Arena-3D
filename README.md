# Shoot Arena 3D Middle Unity Test Project

## Unity version - 2020.3.27f1

# Frameworks:
Extenject

# Plugins
DoTween

# Configuration Data
Configiration is stored in XML files.

### Where to start

Game should be launched from Bootstrap scene
When launched on PC, but want a mobile input, it could be enabled in settings SO.
Settings SO located in Resources folder, under name - application_settings
Just enable Overrride device type to true. 
And select device type - Mobile

### Actual build for Android

Is located under this link - 

### Gameplay

## Player stats

Health - just health by itself.

Ult points - when we reach 100 ult points, we can Ult and all active enemies will die.

We get 50 ult points when kill ranged enemy and 15 for a melee one.

## Player Control

We have 2 types of control:
Mobile - 2 joystics for movement and rotation. 1 fire button and 1 ult button.
Standalone - WASD movement, LMB - shoot, RMB - Ult.

## Enemies

Ranged - Ranged enemy shoot a bullet, when it hits player, we loose ult power.
To avoid the bullet we can jump off the arena and his bullet with loose the target.

Melee - attacks from above, when reached a player, he deals damage to player.

Ranged has 100 hp, 25 damage
Melee has 50 hp, 15 damage

## Waves 

Each wave has 4 melee and 1 range enemy.

Each 5 sec is new respawn.
During each respawn its time decrease by 0.2 sec up until 2 sec min.
