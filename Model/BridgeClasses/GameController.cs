using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Ghosts;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Board;

namespace lp2_rec_ghosts.Model
{
    /// <summary>
    /// Main class to control the flow of the game.
    /// </summary>
    public static class GameController
    {
        /// <summary>
        /// List of Players.
        /// </summary>
        /// <value></value>
        private static Player[] Players {get; set;} = new Player[2]; 
        private static Player CurrentPlayer {get; set;}
        public static bool FastMode {get; private set;} = false;

        public static GameBoard GBoard {get; private set;}


        /// <summary>
        /// Constructor creates the Players and builds the Board. 
        /// </summary>
        public static void SetupGame()
        {
            GBoard = new GameBoard();

            Players[0] = new Player();
            Players[1] = new Player();

            RenderInfo.ScreenMessage("Turn fast mode ON?");
            FastMode = InputReceiver.AskBoolSelect();   
            RenderInfo.ScreenMessage("FastMode is currently: " + FastMode);

            StartGame();
            
        }

        private static void StartGame()
        {
            Players[0].DoTurn();
            Players[0].DoTurn();
            for(int i = 1; i < 1666; i++)
            {
                CurrentPlayer = Players[i % 2];
                CurrentPlayer.DoTurn();
                
                if(FastMode && CurrentPlayer.ScoreTotal >= 3)
                {

                    RenderInfo.ScreenMessage($"Player {i + 1} WINS!");
                    break;
                }
                else if (!FastMode)
                {
                    if( CurrentPlayer.ScoreRed >= 1 && 
                        CurrentPlayer.ScoreBlue >= 1 &&
                        CurrentPlayer.ScoreYellow >= 1)
                    {
                        RenderInfo.ScreenMessage($"Player {i + 1} WINS!");
                        break;
                    }
                }
                    

            }

            EndGame();

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
                GameController.GBoard.DropPlacement = true;
                p.UseGhost(ghost);
            }

            

        }

        private static void EndGame()
        {

            RenderInfo.ScreenMessage("GAME OVER!");

        }

    }
}