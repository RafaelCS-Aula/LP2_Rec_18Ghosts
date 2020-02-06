using System;
using lp2_rec_ghosts.Model;

namespace lp2_rec_ghosts
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard.InitBoard();
            foreach(var v in GameBoard.Board)
            {
                Console.SetCursorPosition(v.Key.X, v.Key.Y);
                Console.Write("e");

            }

                
            
        }
    }
}
