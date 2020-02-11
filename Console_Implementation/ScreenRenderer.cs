using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.Enums;
using System;

namespace lp2_rec_ghosts.Console_Implementation
{
    public class ScreenRenderer: IRenderer
    {
        public void DrawMessage(string msg)
        {


        }



        /// <summary>
        /// Quick helper method to switch the color of the text.
        /// </summary>
        /// <param name="c"> Color to change it to </param>
        private void TextColorSwitcher(Colors c)
        {
            ///<remarks> Taken from 'Linguagens de Programação I' 1st project.
            ///</remarks>     
       
            switch(c)
            {
                case Colors.BLUE:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;

                case Colors.RED:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

                case Colors.YELLOW:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

                default:
                 Console.ForegroundColor = ConsoleColor.White;
                 break;
            }        
        }



        
    }
}