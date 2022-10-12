# Mazeland - Game Project for CSCI526 Fall 2022
# Team
|                   Name                   |       Email      |               Games Played First Week              |              Spurpunk TD review             |   |
|:----------------------------------------:|:----------------:|:--------------------------------------------------:|:-------------------------------------------:|---|
| Shibo Zhang(Team Captain;Enemy Control)  | shibozha@usc.edu | Kingdom Rush 2048 PUBG                             | https://youtu.be/Kke2brSLXVE                |   |
| Mingdong Lyu(Product manager; Analytics) | mingdonl@usc.edu | The binding of Issac Snake 2048 Slay the Spire     | https://youtu.be/HX8jvAXe5ts                |   |
| Zifeng Lin (Version Control)             | zifengli@usc.edu | King of Glory CrossFire QQ Farm                    | https://www.youtube.com/watch?v=iwWn0_tOTyk |   |
| Xiujing Huang (User Interface)           | xiujingh@usc.edu | Detroit become human LOL PUBG                      | https://www.youtube.com/watch?v=Hu2N8fc77CU |   |
| Tianding Zhang(programmer)               | tianding@usc.edu | Kingdom Rush Dota2 LOL                             | https://youtu.be/bNQvSRG7MDE                |   |
| Yintang Yang (Programmer)                | yintangy@usc.edu | Portal2 PUBG Carrot Fantasy                        | https://youtu.be/exPrTCbu-ME                |   |
| Yang Zhang（Game Feel, programmer ）     | yangz673@usc.edu | Risk of Rain 2 Human Fall Flat Portal2 Roach Race  | https://youtu.be/X2eXk2_PhGY                |   |
| Chuanshi Zhu(programmer)                 | zhuchuan@usc.edu | Weiro rpg Among us Richman 10                      | https://youtu.be/_71f3Zo2sL0                |   |
| Ruize Zhang(Product manager,Analytics)   | ruizezha@usc.edu | Sid Meier's Civilization VI Crusader Kings III     | https://www.youtube.com/watch?v=LEytUpuILrM |   |
| Minzhi Zhan(User Interface)              | minzhizh@usc.edu | Animal crossing The legend of zelda Carrot fantasy | https://youtu.be/dsA9ySEOY-s                |   |
| Jerzy Ramos Chen(Programmer)             | ramosche@usc.edu | Don’t Starve, Genshin Impact, Stardew Valley       | https://youtu.be/0amXbrHk1d8                |   |

# WebGL Link
https://mazeland.itch.io/divisible1

# Game Overview
## Genre
Survival, Collecting, Exploration, Math
## Goal
Survive until the last second and collect score to reach goal
## Mechanics
Player uses WASD to move in 2D plane
Player has 3 lives in total and each damage loses one life.
Player eliminates enemies if the number of the enemy is the factor of the number on the player
Player gets scores by collecting green circles or by killing enemies.
Player needs to avoid the black circle and cannot collide with the black circle.
Players can collect green circles with different scores to increase the player’s total score.
Collect enough Scores to reach the next level.
The black circle will shrink as time goes by.
## Math
Controlled random generation for point orbs, enemies, and assigned numbers
 
# Game Description
Last-man-standing gameplay with the survival, exploration and scavenging elements of a survival game


## Detailed Idea:

Move the player orb to collect generated point cubes to increase total score. The player is able to eliminate certain cubes by collision. In the meanwhile, the battleground will gradually shrink to a random size. The play will have to stay in the battleground in order to be alive and reach certain points to level up.
## Drawing:
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture1.jpg?raw=true)

The player can move by using WASD. Collect points by colliding with cubes. Try to collect as many points as possible to level up. Always stay in the safe zone to avoid loss of points.

![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture2.jpg?raw=true)
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture3.jpg?raw=true)
For example, if the player has point 15, the player can kill enemies with number 5 on it. However, the player cannot kill enemies with number 2 on it since 15 is not divisible by 2. If the player with points 15 hits enemies with number 2, the player will get penalties like decreasing two of the total points and generate an enemy with a number which is the reminder of it.
## Drawing for Level 1:
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture4.jpg?raw=true)
Level 1 is the basic idea of the game. It shows the basic game mechanics of the game and helps players get more familiar with our games. The goal for level1 is to collect enough points or kill enough enemies to reach a goal score.

## Drawing for Level 2:
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture5.jpg?raw=true)
Except for the basic game mechanics, the outside circle starts to shrink and the player will get damage if the player hits the balck circle.The goal for level2 is to collect enough points or kill enough enemies to reach a goal score.

## Drawing for Level 3:
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture6.jpg?raw=true)
We add some items in level 3. The first item is “red heart”, players can get one more life if they collect it. The second item is “tornado”. It will increase the players’ movement speed. The goal for level3 is to collect enough points or kill enough enemies to reach a goal score.

## Drawing for Level 4:
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture7.jpg?raw=true)
The level 4 has a stick rotating inside the circle. The circle will no longer shrink and players need to escape from the stick.The goal for level4 is to collect enough points or kill enough enemies to reach a goal score.

## Drawing for Level 5:
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture8.jpg?raw=true)
Players still need to collect as many points as possible to complete this level, but their vision is blocked. They are only able to view a small area around themselves. The goal for level5 is to collect enough points or kill enough enemies to reach a goal score.

## Drawing for Level 6:
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture9.jpg?raw=true)
We add three portals at level 6. Players can travel to another portal if they control the yellow circle and collide with the portal. The goal for level6 is to collect enough points or kill enough enemies to reach a goal score.

# Analysis
## Data collection:
We send our metric to a Google Form through Unity. We can then get a spreadsheet with all the metrics tracked.

![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture10.png?raw=true)

## Data analysis:
We will save the data from the Google Form as the .csv file. The collected variables are starting time for each level, end time for each level, and the dead level for each player. We will then calculate the average survival time and number of players that pass/fail each level with pandas. The results of the data analysis will be plotted out by matplotlib.

![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture11.png?raw=true)

## Data 1
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture13.png?raw=true)

## Data 2
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture14.png?raw=true)

## Data 3
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture15.png?raw=true)

## Data 4
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture16.png?raw=true)

## Data 6
![alt text](https://github.com/Samberg-0808/Mazeland/blob/main/GDD%20figures/Picture17.png?raw=true)




