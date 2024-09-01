1- Multiplayer Mode

   *Feature Description: Introduce a local or online multiplayer mode where two players can compete to see who can last the longest or collect the most stars.
   
   *Implementation:
      
      -For online multiplayer, integrate a networking solution like Photon Unity Networking (PUN) to manage real-time gameplay between players.
      
      -Implement game logic to determine the winner based on survival time or star count, and display a results screen at the end of each match.

2- Power-Ups

   *Feature Description: Introduce power-ups that give temporary abilities to the player, such as invincibility, slow-motion, or double points for star collection.

    *Implementation:

        -Use Unity's OnTriggerEnter2D to detect collisions between the ball and power-ups
        
        -Implement different scripts for each power-up type. For example, the invincibility power-up could disable the collision detection for the ball for a limited time, and the slow-motion power-up could reduce the speed of obstacle rotations.
