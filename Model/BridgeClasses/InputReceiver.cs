using lp2_rec_ghosts.Model.Interfaces;

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

            if(!(x >= 0 && x <= 2)) 
                goto InputRequest;
            if(!(y >= 0 && y <= 18))
                goto InputRequest;

            return new Vector((int)x,(int)y);
        }

    }
}