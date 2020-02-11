using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.Enums;
using lp2_rec_ghosts.Model.Ghosts;
using lp2_rec_ghosts.Model.GameTypes;
using System;
using System.Collections.Generic;

namespace lp2_rec_ghosts.Console_Implementation
{
    public class ScreenRenderer: IRenderer
    {
        // Characters to be used for each element of the board.
        private char tileVisual = '+';
        private char mirrorVisual = 'M';
        private char ghostPlayer1Visual = '@';
        private char ghostPlayer2Visual = '&';
        private char[] portalVisuals = {'↑','→','↓','←'};


        public ScreenRenderer()
        {
            // Set the console windows size.
            // Might break on Linux.
            Console.SetWindowSize(140, 30);
        }

        public void DrawMessage(string msg)
        {
            
            Console.SetCursorPosition(0,25);
            Console.WriteLine("     ");
            Console.WriteLine("     ");
            Console.SetCursorPosition(0,25);
            Console.Write(
                $"Player{GameController.CurrentPlayer.playerNumber}: " + 
                  msg +"\n");

        }

        public void DrawGhostList(GhostObject[][] list)
        {

            DrawPlayerGhostList(GameController.CurrentPlayer, list);
            DrawDungeonGhostList(list[3]);




        }

    /// <summary>
    /// Updates the board tiles and ghosts on screen.
    /// </summary>
    /// <param name="board"></param>
        public void DrawBoard(Dictionary<Vector, IBoardObject[]> board)
        {
            DrawNumbers();

            GhostObject g;
            IBoardObject t;
            
            char c = ' ';
            foreach(KeyValuePair<Vector, IBoardObject[]> k in board)
            {

                // The board
                t = k.Value[0];

                // Draw the ghosts
                g = k.Value[1] as GhostObject;

                if(g != null)
                {
                    if (g.Owner.playerNumber == 1) 
                    c = ghostPlayer1Visual;
                    else if (g.Owner.playerNumber == 2) 
                    c = ghostPlayer2Visual;                   
                }
                else
                {
                    // If it is at the edges don't draw anything as we've
                    // already drawn the numbers
                    if(t.Position.X == 0 || t.Position.Y == 0)
                        continue;
                    if(t.MyColor == Colors.MIRROR)
                        c = mirrorVisual;
                    else if(t.MyColor == Colors.BLOCK)
                    // MAKE PORTALS POINT THE RIGHT WAY
                        c = portalVisuals[0];
                    else
                        c = tileVisual;
                    
                }

                Console.SetCursorPosition(k.Key.X, k.Key.Y);
                TextColorSwitcher(g.MyColor);
                Console.Write(c);
            }
            


        }


        /// <summary>
        /// Draws numbers on the edges of the grid.
        /// </summary>
        /// <remarks> Taken from 'Linguagens de Programação I' 1st project.
        /// </remarks>
        private void DrawNumbers()
        {
            Console.Clear();

            // Row
            Console.WriteLine(" 01234");
            // Column
            Console.Write("0\n1\n2\n3\n4");
        }

        /// <summary>
        /// Quick helper method to switch the color of the text.
        /// </summary>
        /// <param name="c"> Color to change it to </param>
        ///<remarks> Taken from 'Linguagens de Programação I' 1st project.
        ///</remarks>  
        private void TextColorSwitcher(Colors c)
        {
   
       
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

        /// <summary>
        /// Draws the List of Ghosts on scree.
        /// </summary>
        /// <param name="currentPlayer">  Variável do jogador no momento.
        /// </param>
        private void DrawPlayerGhostList(Player currentPlayer,
             GhostObject[][] ghosts)
        {
            // Variável.
            char c = ' ';
            // Cor da consola.
            Console.ForegroundColor = ConsoleColor.White;
            // Acede a classe Ghost.
            GhostObject g;

            // Na posição (30,0) da janela da consola vai ser escrito 
            // "Your Ghosts:".
            Console.SetCursorPosition(30,0);
            Console.Write("Your Ghosts:");

            // Na posição (15,1) da janela da consola vai ser escrito 
            // "Type the number on the left to select them.".
            Console.SetCursorPosition(15,1);
            Console.Write("Type the number on the left to select them.");

            // Na posição (15,2) da janela da consola vai ser escrito 
            // "Then type in grid coordinates to place them.\n".
            Console.SetCursorPosition(15,2);
            Console.Write("Then type in grid coordinates to place them.\n");
            
            // Modifica os visuais dos fantsmas dos jgoadores.
            if (currentPlayer.playerNumber == 1) c = ghostPlayer1Visual;
            else if (currentPlayer.playerNumber == 2) c = ghostPlayer2Visual;

            // Conta quantos fantasmas o jogador tem.
            for(int x = 0; x < 3; x++)
            {
                for (int i = 0; i < ghosts[x].Length; i++)
                {
                Console.CursorLeft = 25;
                g = ghosts[x][i];
                TextColorSwitcher(g.MyColor);
                if(g != null)
                    Console.Write(
                        $"[{i}] - {c}, at ({g.Position.X},{g.Position.Y})\n");

                }


            }
            
        }

        /// <summary>
        /// Draws a list of all the ghosts in the dungeon.
        /// </summary>
        /// <param name="dung"> The array of ghosts in the dungeon </param>
        public void DrawDungeonGhostList(GhostObject[] dung)
        {
            
            char c = ' ';
            // Coloca a cor da consola a branco.
            Console.ForegroundColor = ConsoleColor.White;
            // Acede a classe Ghost.
            GhostObject g;
            
            // Na posição (90, 0) é escrito "Your Ghosts:".
            Console.SetCursorPosition(90,0);
            Console.Write("Your Ghosts in the Dungeon:");

            // Na posição (70, 1) é escrito "Type 'd' + the number on the 
            // left to select them.".
            Console.SetCursorPosition(70,1);
            Console.Write("Type 'd' + the number on the left to select them.");

            // Na posição (70, 2) é escrito "Selecting a ghost in the 
            // Dungeon will give the other player.\n" .
            Console.SetCursorPosition(70,2);
            Console.Write("Selecting a ghost in the Dungeon will give" + 
             "it to the other player.\n");

            // Apresenta os fantasmas de cada jogador na caverna.
            for (int i = 0; i < dung.Length; i++)
            {
                g = dung[i];
                if (g.Owner.playerNumber == 1) c = ghostPlayer1Visual;
                else if (g.Owner.playerNumber == 2) c = ghostPlayer2Visual;
                TextColorSwitcher(g.MyColor);

                Console.CursorLeft = 90;
                Console.Write($"[{i}] - {c}.\n");
            }

            // Make a white line at line 70.
            Console.CursorLeft = 70;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("---------------------------------------------" +
                "-----------");
        }


        
    }
}