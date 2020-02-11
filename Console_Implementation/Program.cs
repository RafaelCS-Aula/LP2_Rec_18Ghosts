using System;
using lp2_rec_ghosts.Model.BridgeClasses;

namespace lp2_rec_ghosts.Console_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
           // Start the game
           Input inputClass = new Input();
           ScreenRenderer RendererClass= new ScreenRenderer();

           GameController.SetupGame();
            
                
            
        }
    }
}
