using System.Collections.Generic;
using lp2_rec_ghosts.Model.Ghosts;

namespace lp2_rec_ghosts.Model
{
    public class Player
    {

        public GhostObject SelectedGhost; 

        private Vector input;

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

        public Player()
        {
            
            for(int i = 0; i < 3; i++)
            {

                myGhosts[0][i] = new RedGhost(this);
                myGhosts[1][i] = new BlueGhost(this);
                myGhosts[2][i] = new YellowGhost(this);

            }


        }

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

        public int GetGhostNumbers(int category)
        {
            int count = 0;

            for(int i = 0; i < myGhosts.GetUpperBound(category); i++)
            {

                if(myGhosts[category][i] != null) count++;

            }

            return count;
        }

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

        public void MoveGhost(GhostObject givenGhost = null)
        {
            if(givenGhost == null)
                givenGhost = SelectedGhost;

            // If it's a dungoned ghost:
            // GameMaster.TransferGhosts(this, SelectedGhost);
            // return

            // Check if tile the ghost is on has any effect on the it
            // BoardAnalyser.ActivateSpecialTile(SelectedGhost.Position)

            // Ask for the valid tiles to place Ghost
            // ValidGridInputs = 
            // BoardAnalyser.GetValidTiles(ColorToMatch: SelectedGhost.MyColor);
            
            
            // Ask for Input
            // Receive it as a Vector.
            // SelectedGhost.Move(input)
            

        }

    }
}