using System.Collections.Generic;

namespace lp2_rec_ghosts.Model
{
    public static class GameBoard
    {

        public static Dictionary<Vector, BoardObject[]> Board 
            {get; private set;} 

        // With (0,0) being the Bottom-Left of the screen    
        public static void InitBoard()
        {

            Board = new Dictionary<Vector, BoardObject[]>();

            // WALLS

            // Bottom Horizontal Wall
            for(int i = 0; i < 6; i++)
            {
                Board.Add(new Vector(i,i), new BoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});
            }

            // Left Vertical Wall
            for(int i = 0; i < 6; i++)
            {
                Board.Add(new Vector(0,i), new BoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});
            }

            // Top Horizontal Wall
            for(int i = 0; i < 6; i++)
            {
                Board.Add(new Vector(i,6), new BoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});
            }

            // Right Vertical Wall
            for(int i = 0; i < 6; i++)
            {
                Board.Add(new Vector(6,i), new BoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});
            }

            // PORTALS

            // Bottom Portal            
            Board.Add(new Vector(3,1), new BoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});

            // Right Portal            
            Board.Add(new Vector(5,3), new BoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});

            // Top Portal            
            Board.Add(new Vector(3,5), new BoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});


            

        }
    }
}