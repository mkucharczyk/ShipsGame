## Ships Game
Simple one sided game of ships. Ships are randomly generated at start of game.
You play game by typing coordinates of field you want to hit. 
Game ends when you sink all the ships.

There is 4 possible results of hit:
- Hit - you hit ship!
- Miss - There was nothing on that field 
- Sink - The ship that got hit have sunk
- Invalid - Coordinates you provided are invalid or that field was already hit before

Game is configured in appsettings.json

### Board
By default board is 10x10 and you need to sink 3 ships - 2 Destroyers(4 fields) and 1 Battleship(5 fields).
On board there are specific markings of fields:
- O - means field wasn't hit before
- S - Ship was hit/sunk on that field
- X - Field was hit and it was miss
