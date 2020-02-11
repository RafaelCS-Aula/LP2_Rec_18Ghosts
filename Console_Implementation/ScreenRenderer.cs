using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.Enums;
using lp2_rec_ghosts.Model.Ghosts;
using lp2_rec_ghosts.Model.GameTypes;
using System;
using System.Collections.Generic;

namespace lp2_rec_ghosts.Console_Implementation
{
    /// <summary>
    /// Console App implementaion of the Renderer for the Model game's state.
    /// </summary>
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

            // Make it so the console can output special characters.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            RenderInfo.OutsideRenderer = this;
        }

        /// <summary>
        /// Implementation of IRenderer.DrawMessage();
        /// </summary>
        public void DrawMessage(string msg)
        {
            
            Console.SetCursorPosition(0,25);
            Console.WriteLine("     ");
            Console.WriteLine("     ");
            Console.SetCursorPosition(0,25);
            Console.Write(
                $"Player{GameController.CurrentPlayer?.playerNumber}: " + 
                  msg +"\n");

        }

        /// <summary>
        /// Implementation of IRenderer.DrawGhostList
        /// </summary>
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

                    TextColorSwitcher(g.MyColor);               
                }
                else // If there's no ghost on the tile just draw the tile.
                {
                    // If it is at the edges don't draw anything as we've
                    // already drawn the numbers
                    if(t.Position.X == 0 || t.Position.Y == 0)
                        continue;
                    if (t.MyColor == Colors.MIRROR)
                        c = mirrorVisual;
                    else if (t.MyColor.HasFlag(Colors.BLOCK))
                    {
                        if (t.MyColor == Colors.BLOCK)
                        {
                            c = ' ';
                        }
                        else
                            //TODO: MAKE PORTALS POINT THE RIGHT WAY
                            c = portalVisuals[0];
                    }
                        
                    else
                        c = tileVisual;

                    TextColorSwitcher(t.MyColor);
                    
                }

                // Console windows' 0,0 is at the top left instead of bottom.
                // 3 is the middle row, we use it as the mirror axis.
                int mirrorY = 3 - (k.Key.Y - 3);


                Console.SetCursorPosition(k.Key.X, mirrorY);
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

            Console.SetCursorPosition(0, 6);
            // Row
            Console.WriteLine("012345");

            Console.SetCursorPosition(0, 0);
            // Column
            Console.Write("0\n5\n4\n3\n2\n1");
        }

        /// <summary>
        /// Quick helper method to switch the color of the text.
        /// </summary>
        /// <param name="c"> Color to change it to </param>
        ///<remarks> Taken from 'Linguagens de Programação I' 1st project.
        ///</remarks>  
        private void TextColorSwitcher(Colors c)
        {
            if(c.HasFlag(Colors.BLUE))
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (c.HasFlag(Colors.RED))
                Console.ForegroundColor = ConsoleColor.Red;
            else if (c.HasFlag(Colors.YELLOW))
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.White;
 
        }

        /// <summary>
        /// Draws the List of Ghosts on scree.
        /// </summary>
        /// <param name="currentPlayer">  Variável do jogador no momento.
        /// </param>
        ///<remarks> Taken from 'Linguagens de Programação I' 1st project.
        ///</remarks>
        private void DrawPlayerGhostList(Player currentPlayer,
             GhostObject[][] ghosts)
        {
            
            char c = ' ';
            
            Console.ForegroundColor = ConsoleColor.White;
            
            GhostObject g;


            Console.SetCursorPosition(30,0);
            Console.Write("Your Ghosts:");

   
            Console.SetCursorPosition(15,1);
            Console.Write("Type the number on the left to select them.");

     
            Console.SetCursorPosition(15,2);
            Console.Write("Then type in grid coordinates to place them.\n");
            
            // Render each ghost according to it's owner.
            if (currentPlayer.playerNumber == 1) c = ghostPlayer1Visual;
            else if (currentPlayer.playerNumber == 2) c = ghostPlayer2Visual;

            
            for(int x = 0; x < 3; x++)
            {
                for (int i = 0; i < ghosts[x].Length; i++)
                {
                    Console.CursorLeft = 25;
                    g = ghosts[x][i];
                
                    if(g != null)
                    {
                        TextColorSwitcher(g.MyColor);
                        Console.Write(
                            $"[{x},{i}] - {c}, at ({g.Position.X}," +
                            $"{g.Position.Y}) \n");
                    }
                    else
                    {
                        
                        TextColorSwitcher(Colors.BLOCK);
                        Console.Write($"[{x},{i}] -----");

                    }
                        
                
                    

                }


            }
            
        }

        /// <summary>
        /// Draws a list of all the ghosts in the dungeon.
        /// </summary>
        /// <param name="dung"> The array of ghosts in the dungeon </param>
        ///<remarks> Taken from 'Linguagens de Programação I' 1st project.
        ///</remarks>
        public void DrawDungeonGhostList(GhostObject[] dung)
        {
            
            char c = ' ';
            
            Console.ForegroundColor = ConsoleColor.White;
           
            GhostObject g;
            
            // Tell the players some instructions
            Console.SetCursorPosition(90,0);
            Console.Write("Your Ghosts in the Dungeon:");


            Console.SetCursorPosition(70,2);
            Console.Write("Selecting a ghost in the Dungeon will give" + 
             "it to the other player.\n");

            // Shows all the ghosts in the dungeon
            for (int i = 0; i < dung.Length; i++)
            {
                g = dung[i];

                if(g != null)
                {
                    if (g.Owner.playerNumber == 1) c = ghostPlayer1Visual;
                    else if (g.Owner.playerNumber == 2) c = ghostPlayer2Visual;
                    TextColorSwitcher(g.MyColor);
                    Console.CursorLeft = 90;
                    Console.Write($"[4,{i}] - {c}.\n");                    
                }
                else 
                {
                    Console.CursorLeft = 90;
                    Console.Write($"[4,{i}] ------ \n");                    

                }



            }

            // Make a white line at line 70.
            Console.CursorLeft = 70;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("---------------------------------------------" +
                "-----------");
        }


        
    }
}