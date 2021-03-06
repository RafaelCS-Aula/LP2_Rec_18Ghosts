using System.Collections.Generic;
using System.Linq;
using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.Ghosts;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Enums;
using lp2_rec_ghosts.Model.BridgeClasses;

namespace lp2_rec_ghosts.Model.Board
{
    /// <summary>
    /// Manages the Gameboard and supplies methods for outside classes to
    /// get info on the board.
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// Whether the current ghost will be moved by going to an adjacent tile
        /// or bey being "dropped" into a tile anywhere on the board.
        /// </summary>
        public bool DropPlacement = false;

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
        public static Dictionary<Vector, IBoardObject[]> Board 
            {get; private set;} = new Dictionary<Vector, IBoardObject[]>();


        private PortalDummyGhost RedDummy;
        private PortalDummyGhost BlueDummy;
        private PortalDummyGhost YellowDummy;

        /// <summary>
        /// Creates the board in it's inicial state.
        /// </summary>
        public GameBoard()
        {
            RedDummy = new PortalDummyGhost(Colors.RED);
            BlueDummy = new PortalDummyGhost(Colors.BLUE);
            YellowDummy = new PortalDummyGhost(Colors.YELLOW);

            // With (0,0) being the Bottom-Left of the screen  
            // However in the console window it is the Top-Left  


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

            IBoardObject[] gridSpace;
            // Bottom Portal            
            Board.Add(new Vector(3,1), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK | Colors.BLUE), null, null});

            // Corresponding dummy ghost.
            Board.TryGetValue(new Vector(3,0), out gridSpace );
            gridSpace[2] = BlueDummy;
            BlueDummy.Position = new Vector(3,0);

            
            // Right Portal            
            Board.Add(new Vector(5,3), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK | Colors.YELLOW), null, null});

            // Corresponding dummy ghost.
            Board.TryGetValue(new Vector(6,3), out gridSpace );
            gridSpace[2] = YellowDummy;
            YellowDummy.Position = new Vector(6,3);

            // Top Portal            
            Board.Add(new Vector(3,5), new IBoardObject[3]
                {new CarpetTile(Colors.BLOCK | Colors.RED), null, null});

            // Corresponding dummy ghost.
            Board.TryGetValue(new Vector(3,6), out gridSpace );
            gridSpace[2] = RedDummy;
            RedDummy.Position = new Vector(3,6);
           

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



            IBoardObject[] tile;
            // Update the position properties in the tiles themselves
            for(int x = 0; x < 7; x++)
            {
                for(int y = 0; y < 7; y++)
                {   
                    Board.TryGetValue(new Vector(x,y), out tile);

                    tile[0].Position = new Vector(x,y);
                }


            }


            RenderInfo.UpdateBoardDraw(Board);
        }

        /// <summary>
        /// Check the current position on the grid's tile layer for any tiles
        /// that have special logic when the Ghost on them is selected, and
        /// run it.
        /// </summary>
        /// <param name="tilePosition"> The grid position of the Tile to be
        /// checked.</param>
        public void ActivateSpecialTile(Vector tilePosition)
        {
            IBoardObject[] tile;
            Board.TryGetValue(tilePosition, out tile);
            ISelectionInteractable specialTile 
                = (tile[0] as ISelectionInteractable);

            specialTile?.OnSelectedInteraction();


        }

        /// <summary>
        /// Get the grid positions a Ghost can move to in either types of 
        /// movement.
        /// </summary>
        /// <param name="ghost"> The ghost that the player wants to move.
        /// </param>
        /// <returns> A Vector array with all the valid positions.</returns>
        public Vector[] GetValidTiles(GhostObject ghost)
        {   
            if(DropPlacement)
                return GetDropSpots(ghost).ToArray();
            else    
                return GetSlideSpots(ghost).ToArray();
                


        }

        /// <summary>
        /// Check the Ghost's neighbouring positions and return the ones valid
        /// for being moved into.
        /// </summary>
        /// <param name="ghost"> The ghost that the player wants to move. 
        /// </param>
        /// <returns> A collection of all the valid tile positions.
        /// </returns>
        private IEnumerable<Vector> GetSlideSpots(GhostObject ghost)
        {

            IBoardObject[] currentSpace;

            if(Board.TryGetValue(ghost.Position, out currentSpace))
            {
                foreach(Vector v in ghost.Neighbours())
                {
                    Board.TryGetValue(v, out currentSpace);
                    

                    if(currentSpace[0].MyColor != Colors.BLOCK)
                    {
                        if(currentSpace[1] == null) 
                            yield return v;
                        else if (currentSpace[1] != null && 
                            currentSpace[1].MyColor != ghost.MyColor)
                                yield return v;
                    }


                }

            }

        }

        /// <summary>
        /// Check the board for tiles with a certain color:
        /// First the tiles that match the color of the Ghost's tile.
        /// And if that doesn't work, the tiles that match the color of the
        /// Ghost itself.
        /// </summary>
        /// <param name="ghost"> The ghost that the player wants to move.
        /// </param>
        /// <returns> A collection of all the valid tile positions. </returns>
        private IEnumerable<Vector> GetDropSpots(GhostObject ghost)
        {

            Colors colorToMatch = Colors.BLOCK;
            IBoardObject[] currentSpace;

            if(Board.TryGetValue(ghost.Position, out currentSpace))
            {
                if(currentSpace[0].MyColor == Colors.BLOCK) 
                    colorToMatch = ghost.MyColor;
                else 
                    colorToMatch = currentSpace[0].MyColor;

            }

            foreach(KeyValuePair<Vector, IBoardObject[]> g in Board)
            {

                if(g.Value[0].MyColor == colorToMatch && 
                    g.Value[1] == null )
                    {
                        yield return g.Key;

                    }

            }


        }

        /// <summary>
        /// Moves the dummy ghost to the next aproppriate location
        /// </summary>
        /// <param name="Color"> Color of the ghost who died. </param>
        public void RotatePortal(Colors Color)
        {
            switch(Color)
            {
                case(Colors.RED):
                    RedDummy.Move();
                    break;
                case(Colors.BLUE):
                    BlueDummy.Move();
                    break;
                case(Colors.YELLOW):
                    YellowDummy.Move();
                    break;
                default:
                    break;


            }
        }

        /// <summary>
        /// Update the board itself to reflect the changes made to Ghosts' 
        /// positions over time.
        /// </summary>
        /// <param name="ghost"> Ghost who will be put on the board's layer
        /// </param>
        public void UpdateGhostOnBoard(GhostObject ghost)
        { 
            IBoardObject[] currentSpace;

            Board.TryGetValue(ghost.Position, out currentSpace);

            if(currentSpace[1] != null)
                currentSpace[1] = null;
            currentSpace[1] = ghost;

            RenderInfo.UpdateBoardDraw(Board);

        }
    
    }
}