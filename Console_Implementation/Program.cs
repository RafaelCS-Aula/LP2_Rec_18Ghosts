using System;
using lp2_rec_ghosts.Model.BridgeClasses;

namespace lp2_rec_ghosts.Console_Implementation
{
    /// <summary>
    /// Beginning of the program
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
           // Instance the implementation classes
           Input inputClass = new Input();
           ScreenRenderer RendererClass= new ScreenRenderer();

            // Start the game
           GameController.SetupGame();
            
                
            
        }
    }
}
