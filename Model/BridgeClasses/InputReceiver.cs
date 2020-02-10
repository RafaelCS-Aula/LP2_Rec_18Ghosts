using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.Ghosts;
using lp2_rec_ghosts.Model.GameTypes;

namespace lp2_rec_ghosts.Model.BridgeClasses
{
    /// <summary>
    /// Class that will enter contact with the classes outside the Model
    /// with the purpose of receiving input and making sure it is game valid.
    /// </summary>
    public static class InputReceiver
    {
        
        /// <summary>
        /// Outside class used for Input handling.
        /// </summary>
        public static IInputHandler InputSender {get; set;}

        private static Vector[] ValidGridInputs;
    
        /// <summary>
        /// Ask the outer class for input and wait until it gets a valid one.
        /// </summary>
        /// <returns> A Vector with x:[0,2] and y:[0,18]</returns>
        public static Vector AskGhostSelect()
        {
            float x, y;

            InputRequest:
                RenderInfo.ScreenMessage("Select a Ghost");
                InputSender.AwaitVectorInput(out x, out y);

            if(!(x >= 0 && x <= 2) && !(y >= 0 && y <= 18) )
            {
                RenderInfo.ScreenMessage("Invalid Input!");
                goto InputRequest;
            } 
                


            return new Vector((int)x,(int)y);
        }

        /// <summary>
        /// Asks the outside Input class for Input and then 
        /// evalute it in the context of the board grid.
        /// </summary>
        /// <param name="ghostToBeMoved"> The Ghost that the player
        /// wants to move.</param>
        /// <returns> A valid grid position for the Ghost to be moved into
        /// </returns>
        public static Vector AskTileSelect(GhostObject ghostToBeMoved)
        {
            ValidGridInputs = 
                GameController.GBoard.GetValidTiles(ghostToBeMoved);

            float x, y;

            InputRequest:
                RenderInfo.ScreenMessage("Select a Tile");
                InputSender.AwaitVectorInput(out x, out y);

            foreach(Vector v in ValidGridInputs)
            {
                if(!(v.X == x && v.Y == y))
                {
                    RenderInfo.ScreenMessage("Invalid Tile!");
                    goto InputRequest;
                }
                else 
                    break;
            }

            return new Vector((int)x, (int)y);

        }

        public static bool AskBoolSelect() => InputSender.AwaitBoolInput();


    }
}