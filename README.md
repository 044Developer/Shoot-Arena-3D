# Shoot Arena 3D Middle Unity Test Project

## Unity version - 2020.3.27f1

## Frameworks:
Extenject - Project Architecture, Pools, Factories

## Plugins
DoTween - UI Animations

## Patterns
- State
- Factory
- Mediator

## Configuration Data

All configuration data is stored in XML files located in Resources/Scenario folder.

### Where to start

To properly start the game, please enter **Bootstrap** scene.
Game has 2 types of control: Standalone keyboard and Mobile joystics.
When launched on PC, but Mobile input needed, please switch **Override** bool to true in app settings Scriptable Object.
This settings file is located in Resources folder.

# Actual build for Android

Is located under this link - [Download Link](https://drive.google.com/file/d/1TpAAEnbxWi8ldHHm1oXixf65U8Kf6-Oe/view?usp=drive_link)

# Gameplay

## Player stats

Health - just health by itself.

Ult points - when we reach 100 ult points, we can Ult and all active enemies will die.

We get 50 ult points when ranged enemy killed and 15 points for a melee one.

## Player Control

We have 2 types of control:
Mobile - 2 joystics for movement and rotation. 1 fire button and 1 ult button.
Standalone - WASD movement, LMB - shoot, RMB - Ult.

## Enemies

Ranged - Ranged enemy shoot a bullet, when it hits a player, we loose ult power.
To avoid the bullet we can jump off the arena and that bullet with loose the target.

Melee - attacks from above, when reached a player, he deals damage to player.

Ranged has 100 hp and deals 25 damage
Melee has 50 hp and deals 15 damage

## Waves 

1 respawn wave consists of 4 melee enemies and 1 ranged one.

Each 5 sec is new respawn.
During this time, we check the survived enemies on scene, and spawn the rest.
During each respawn, the respawn time decreases by 0.2 seconds.
When respawn time reach 2 seconds, we will no longer decrease the time.
But we spawn 4 melee and 1 ranged enemy on arena, not matter how many of them survived.
