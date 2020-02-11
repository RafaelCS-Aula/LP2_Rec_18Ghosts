using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Interfaces;
using System;

namespace lp2_rec_ghosts.Console_Implementation
{
    public class Input: IInputHandler
    {

        private string inputedText;

        /// <summary>
        /// Awaits for and parses the users input to fit a vector format
        /// </summary>
        /// <param name="x"> X Component of Vector</param>
        /// <param name="y">Y Component of Vector</param>
        public void AwaitVectorInput(out float x, out float y)
        {
            string[] splitInput;

            Request:
                WaitInput();

            // The expected string is in the format "...,..." but the splitter
            // uses more than ',' just in case.
            splitInput = inputedText.Split(
                new char[]{',','.',' '}, StringSplitOptions.RemoveEmptyEntries);

            // If the split didn't result in 2 strings to be parsed then it's
            // already invalid
            if(splitInput.Length != 2)
                goto Request;

            // if the results cant be parsed into numbers, ask again.
            if(!float.TryParse(splitInput[0], out x) ||
                !float.TryParse(splitInput[1], out y))
                goto Request;


        }           

        


        private void WaitInput() => inputedText = Console.ReadLine();

    }
}