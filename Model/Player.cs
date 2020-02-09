using System.Collections.Generic;
using lp2_rec_ghosts.Model.Ghosts;

namespace lp2_rec_ghosts.Model
{
    public class Player
    {

        public int ScoreRed {get; private set;}
        public int ScoreBlue {get; private set;}
        public int ScoreYellow {get; private set;}
        public int ScoreTotal{get; private set;}


        /// <summary>
        /// The Ghost currently being affected by the input received
        /// </summary>
        private GhostObject SelectedGhost; 

        /// <summary>
        /// The input the Player will use to control the Ghost.
        /// </summary>
        private Vector input;

        /// <summary>
        /// The valid positions the Ghost can be moved to.
        /// </summary>
        private Vector[] validGridInputs;

        /// <summary>
        /// All the ghosts in the player's control, divided by color and
        /// whether they are in the dungeon or not.
        /// </summary>
        private GhostObject[][] myGhosts {get; set;} =
        {
            /// <remarks> Red Ghosts go in this array.</remarks>
            new GhostObject[6],

            /// <remarks> Blue Ghosts go in this array. </remarks>
            new GhostObject[6],

            /// <remarks> Yellow Ghosts go in this array. </remarks>
            new GhostObject[6],

            /// <remarks> Ghosts in the dungeon go in this array </remarks>
            new GhostObject[18]
        };

        /// <summary>
        /// Controls Ghosts trough Input and manages it's own list.
        /// </summary>
        public Player()
        {
            
            for(int i = 0; i < 3; i++)
            {

                myGhosts[0][i] = new RedGhost(this);
                myGhosts[1][i] = new BlueGhost(this);
                myGhosts[2][i] = new YellowGhost(this);

            }


        }

        /// <summary>
        /// The turn process of one single Player.
        /// </summary>
        public void DoTurn()
        {

            // Ask for Input
            // Receive the Input as a Vector with x:[0,2] and y:[0,18]

            // inp = InputReceiver.AskVector(2,18)
            
            // Select a Ghost
            int nonNullGhosts = GetGhostNumbers(input.X);
            if(input.Y > nonNullGhosts)  
                SelectedGhost = myGhosts[input.X][nonNullGhosts];
            else    
                SelectedGhost = myGhosts[input.X][input.Y];

            MoveGhost();


        }

        /// <summary>
        /// Get the amount of ghosts in the specified category of the Player's
        /// Ghost inventory.
        /// </summary>
        /// <param name="category"> The index of the jagged array in the first
        /// dimension of the inventory, which specifies the kind of
        /// ghost in the second dimension or in the Dungeon (index 4) </param>
        /// <returns></returns>
        public int GetGhostNumbers(int category)
        {
            int count = 0;

            for(int i = 0; i < myGhosts.GetUpperBound(category); i++)
            {

                if(myGhosts[category][i] != null) count++;

            }

            return count;
        }

        /// <summary>
        /// Put this Ghost in the Dungeon array of the jagged Ghost collection
        /// and remove it from the other array where it is at now.
        /// </summary>
        /// <param name="ghost"> The ghost to be moved around.</param>
        public void SendGhostToDungeon(GhostObject ghost)
        {
            GhostObject ghostInList = null;

            // find the desired ghost
            for (int i = 0; i < 3; i++)
            {
                for(int z = 0; z < 6; i++)
                {

                    if(myGhosts[i][z].Equals(ghost))
                    {
                        ghostInList = ghost;
                        myGhosts[i][z] = null;
                        break;
                    }
                }
            }

            myGhosts[4][GetGhostNumbers(4)] = ghostInList;

        }


        public void UpdateScores(Colors escapedGhostColor)
        {
            switch(escapedGhostColor)
            {
                case Colors.RED:
                    ScoreRed++;
                    break;
                case Colors.BLUE:
                    ScoreBlue++;
                    break;
                case Colors.YELLOW:
                    ScoreYellow++;
                    break;
                default:
                    break;
            }

            ScoreTotal = ScoreYellow + ScoreRed + ScoreBlue;

        }

        /// <summary>
        /// Use input and move the selected Ghost to a tile on the board.
        /// </summary>
        /// <param name="givenGhost"> Null by default. Use a Ghost other 
        /// than the one currently selected by Input.</param>
        public void MoveGhost(GhostObject givenGhost = null)
        {
            if(givenGhost == null)
                givenGhost = SelectedGhost;

            // If it's a dungoned ghost:
            // GameMaster.TransferGhosts(this, SelectedGhost);
            // return

            // Check if tile the ghost is on has any effect on the it
            // GameBoard.ActivateSpecialTile(SelectedGhost.Position)

            // Ask for the valid tiles to place Ghost
            // ValidGridInputs = 
            // GameBoard.GetValidTiles(ColorToMatch: SelectedGhost.MyColor);
            
            
            // Ask for Input
            // Receive it as a Vector.
            // SelectedGhost.Move(input)
            

        }

    }
}