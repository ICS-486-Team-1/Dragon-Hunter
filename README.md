# Dragon-Hunter
Augmented Reality Game created in Fall 2020 by ICS 486 Team 1

## Video List & Descriptions

### v1.0
- able to spawn dragons
- creates line renderer using raycast to interact with dragons
- line renderer does not interact with dragons yet

### v1.1
- set up collision detection, line renderer able to interact and destroy dragons
- created explosion particle system and added in explosion sound effect to play for death of dragon
- added in sound effect of laser shooting

### v1.2
- added in main menu scene, contains:
  * play button to start game
  * about button to give short description of game
  * quit button to exit application
  * background music for opening scene
- added in score tracker to keep track of dragons destroyed
- added in visual target in center of screen for user to use for aim

### v1.3
- change line renderer laser to rocket projectile instead
- update collision detection from raycast to using OnCollisionEnter

### v1.4
- added in proximity sound effects for moving dragons, able to detect location of dragon with earphones in
- added pause menu in, contains:
  * resume button to continue game
  * quit button to return to main menu scene
  
### v1.5 (Final Version)
- add in fire button to fix bug where when clicking on resume in pause menu, it fired a rocket
- added in victory screen to stop the game after shooting all 10 spawned dragons, screen contains:
  * victory message to congratulate user for winning
  * quit button to return to home screen
- update main menu quit button to exit button
- update ui of buttons 
