using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Ghosts;

namespace lp2_rec_ghosts.Model
{
    /// <summary>
    /// Main class to control the flow of the game.
    /// </summary>
    public class GameController
    {
        /// <summary>
        /// List of Players.
        /// </summary>
        /// <value></value>
        private static Player[] Players {get; set;} = new Player[2]; 

        /// <summary>
        /// Constructor creates the Players and builds the Board. 
        /// </summary>
        public GameController()
        {
            Players[0] = new Player();
            Players[1] = new Player();

            GameBoard.BuildBoard();
            StartGame();
            
        }

        private void StartGame()
        {


            // Execute one turn
            Turn();
        }

        /// <summary>
        /// Logic of 1 in-game turn.
        /// </summary>
        private void Turn()
        {


            
        }

        public static void TransferGhost(
            Player sender, GhostObject ghost)
        {
            sender.BustGhost(ghost, false);
            foreach(Player p in Players)
            {
                if(!p.Equals(sender))
                    p.AddGhost(ghost);

                ghost.InDungeon = false;
                GameBoard.DropPlacement = true;
                p.UseGhost(ghost);
            }

            

        }


    }
}