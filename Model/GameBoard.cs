using System.Collections.Generic;
using lp2_rec_ghosts.Model.Interfaces;

namespace lp2_rec_ghosts.Model
{
    public class GameBoard
    {
        /// <summary>
        /// The gameBoard itself stored as a collection of its grid positions
        /// and the corresponding objects.
        /// </summary>
        /// <typeparam name="Vector"> All the grid positions on the board
        /// </typeparam>
        /// <typeparam name="IBoardObject[]"> An array of all the objects
        /// that will be placed on the board at a specific grid position.
        /// The index indicates the "layer" of that object with the first
        /// layer [0] being the static objects on the board (tiles/walls)
        /// the second [1] where the Ghosts are and the third [2] is
        /// where the dummy portal ghosts are.</typeparam>
        public Dictionary<Vector, IBoardObject[]> Board 
            {get; private set;} = new Dictionary<Vector, IBoardObject[]>();

        // With (0,0) being the Bottom-Left of the screen  
        // However in the console window it is the Top-Left  

        /// <summary>
        /// Creates the board in it's inicial state.
        /// </summary>
        public void BuildBoard()
        {

            // WALLS

            // Top Horizontal Wall
            for(int i = 1; i < 6; i++)
            {
                Board.Add(new Vector(i,0), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});
            }

            // Bottom Horizontal Wall
            for(int i = 1; i < 6; i++)
            {
                Board.Add(new Vector(i,6), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});
            }

            // Left Vertical Wall
            for(int i = 0; i <= 6; i++)
            {
                Board.Add(new Vector(0,i), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});
            }



            // Right Vertical Wall
            for(int i = 0; i <= 6; i++)
            {
                Board.Add(new Vector(6,i), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});
            }

            // PORTALS

            // Bottom Portal            
            Board.Add(new Vector(3,1), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});

            // Right Portal            
            Board.Add(new Vector(5,3), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});

            // Top Portal            
            Board.Add(new Vector(3,5), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK), null, null});


            // CARPETS

            // Top Row
            Board.Add(new Vector(1,5), new IBoardObject[3]
                {new CarpetTile(Colors.BLUE), null, null});
            Board.Add(new Vector(2,5), new IBoardObject[3]
                {new CarpetTile(Colors.RED), null, null});
            Board.Add(new Vector(4,5), new IBoardObject[3]
                {new CarpetTile(Colors.BLUE), null, null});
            Board.Add(new Vector(5,5), new IBoardObject[3]
                {new CarpetTile(Colors.RED), null, null});
            
            // 4th Row
            Board.Add(new Vector(1,4), new IBoardObject[3]
                {new CarpetTile(Colors.YELLOW), null, null});
            Board.Add(new Vector(2,4), new IBoardObject[3]
                {new MirrorTile(), null, null});
            Board.Add(new Vector(3,4), new IBoardObject[3]
                {new CarpetTile(Colors.YELLOW), null, null});
            Board.Add(new Vector(4,4), new IBoardObject[3]
                {new MirrorTile(), null, null});
            Board.Add(new Vector(5,4), new IBoardObject[3]
                {new CarpetTile(Colors.YELLOW), null, null});

            // 3rd Row
            Board.Add(new Vector(1,3), new IBoardObject[3]
                {new CarpetTile(Colors.RED), null, null});
            Board.Add(new Vector(2,3), new IBoardObject[3]
                {new CarpetTile(Colors.BLUE), null, null});
            Board.Add(new Vector(3,3), new IBoardObject[3]
                {new CarpetTile(Colors.RED), null, null});
            Board.Add(new Vector(4,3), new IBoardObject[3]
                {new CarpetTile(Colors.BLUE), null, null});

            // 2nd Row
            Board.Add(new Vector(1,2), new IBoardObject[3]
                {new CarpetTile(Colors.BLUE), null, null});
            Board.Add(new Vector(2,2), new IBoardObject[3]
                {new MirrorTile(), null, null});
            Board.Add(new Vector(3,2), new IBoardObject[3]
                {new CarpetTile(Colors.YELLOW), null, null});
            Board.Add(new Vector(4,2), new IBoardObject[3]
                {new MirrorTile(), null, null});
            Board.Add(new Vector(5,2), new IBoardObject[3]
                {new CarpetTile(Colors.RED), null, null});

            // 1st Row
            Board.Add(new Vector(1,1), new IBoardObject[3]
                {new CarpetTile(Colors.YELLOW), null, null});
            Board.Add(new Vector(2,1), new IBoardObject[3]
                {new CarpetTile(Colors.RED), null, null});
            Board.Add(new Vector(4,1), new IBoardObject[3]
                {new CarpetTile(Colors.BLUE), null, null});
            Board.Add(new Vector(5,1), new IBoardObject[3]
                {new CarpetTile(Colors.YELLOW), null, null});
        }
    }
}