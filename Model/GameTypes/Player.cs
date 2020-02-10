using lp2_rec_ghosts.Model.Ghosts;
using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Enums;

namespace lp2_rec_ghosts.Model.GameTypes
{
    public class Player
    {
        // All the Scores that are kept updated to evaluate the win condition.

        /// <summary>
        /// Player's Red Ghosts that have escaped.
        /// </summary>
        public int ScoreRed {get; private set;}

        /// <summary>
        /// Player's Blue Ghosts that have escaped.
        /// </summary>
        public int ScoreBlue {get; private set;}

        /// <summary>
        /// Player's Yellow Ghosts that have escaped.
        /// </summary>
        public int ScoreYellow {get; private set;}

        /// <summary>
        /// Total number of the Player's Ghosts that have escaped.
        /// </summary>
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
        /// Begin the Player's turn, asking for input to select a Ghost.
        /// </summary>
        public void DoTurn()
        {

            RenderInfo.UpdateGhostListing(myGhosts);

            // Ask for Input
            // Receive the Input as a Vector with x:[0,2] and y:[0,18]

            input = InputReceiver.AskGhostSelect();
            
            // Select a Ghost
            int nonNullGhosts = GetGhostNumbers(input.X);
            if(input.Y > nonNullGhosts)  
                SelectedGhost = myGhosts[input.X][nonNullGhosts];
            else    
                SelectedGhost = myGhosts[input.X][input.Y];

            UseGhost();


        }

        /// <summary>
        /// Get the amount of ghosts in the specified category of the Player's
        /// Ghost inventory.
        /// </summary>
        /// <param name="category"> The index of the jagged array in the first
        /// dimension of the inventory, which specifies the kind of
        /// ghost in the second dimension or in the Dungeon (index 3) </param>
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

            ghostInList.InDungeon = true;
            myGhosts[3][GetGhostNumbers(3)] = ghostInList;

        }

        /// <summary>
        /// Remove Ghosts from the player's list of Ghosts.
        /// And call the score updater.
        /// </summary>
        /// <param name="goneGhost"> Ghost to be removed< /param>
        /// <param name="updateScores"> Whether the Player's score should
        /// be updated witht he removal of the ghost.</param>
        public void BustGhost(GhostObject goneGhost, bool updateScores)
        {

            // find the desired ghost
            for (int i = 0; i < 3; i++)
            {
                for(int z = 0; z < 6; i++)
                {

                    if(myGhosts[i][z].Equals(goneGhost))
                    {
                        myGhosts[i][z] = null;
                        break;
                    }
                }
            }

            if(updateScores)
                UpdateScores(goneGhost.MyColor);

        }

        /// <summary>
        /// Add a Ghost to the last available spot in the 
        /// adequate array in the player's ghost inventory.
        /// </summary>
        /// <param name="ghost"> Ghost to join the Player's side. </param>
        public void AddGhost(GhostObject ghost)
        {
            switch(ghost.MyColor)
            {
                case (Colors.RED):
                    myGhosts[0][GetGhostNumbers(0) - 1] = ghost;
                    break;
                case (Colors.BLUE):
                    myGhosts[1][GetGhostNumbers(0) - 1] = ghost;
                    break;
                case (Colors.YELLOW):
                    myGhosts[2][GetGhostNumbers(0) - 1] = ghost;
                    break;
            }


        }

        /// <summary>
        /// Add to the player's score depending on color of Ghost.null
        /// Also updates total score of player.
        /// </summary>
        /// <param name="escapedGhostColor"> Ghost that escaped </param>
        private void UpdateScores(Colors escapedGhostColor)
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
        public void UseGhost(GhostObject givenGhost = null)
        {
            if(givenGhost == null)
                givenGhost = SelectedGhost;

            // If it's a dungeoned ghost:
            if(givenGhost.InDungeon)
            {

                GameController.TransferGhost(this, givenGhost);
                return;

            }


            // Check if tile the ghost is on has any effect on the it
            GameController.GBoard.ActivateSpecialTile(givenGhost.Position);

            
            // Ask for Input
            // Receive it as a Vector.
            
            input = InputReceiver.AskTileSelect(givenGhost);

            SelectedGhost.Move(input);
            

        }

    }
}