using lp2_rec_ghosts.Model.BridgeClasses;
using lp2_rec_ghosts.Model.Ghosts;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Board;

namespace lp2_rec_ghosts.Model.BridgeClasses
{
    /// <summary>
    /// Main class to control the flow of the game.
    /// </summary>
    public static class GameController
    {
        /// <summary>
        /// List of Players.
        /// </summary>
        private static Player[] Players {get; set;} = new Player[2]; 

        /// <summary>
        /// Player whose turn is up.
        /// </summary>
        private static Player CurrentPlayer {get; set;}

        /// <summary>
        /// What the win condition is.
        /// </summary>
        /// <value> TRUE: 3 escaped Ghosts of any color.
        /// FALSE: Atleast 1 escaped Ghost of each color.</value>
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
            Players[0].playerNumber = 1;
            Players[1].playerNumber = 2;

            RenderInfo.ScreenMessage("Turn fast mode ON?");
            FastMode = InputReceiver.AskBoolSelect();   
            RenderInfo.ScreenMessage("FastMode is currently: " + FastMode);

            StartGame();
            
        }

        /// <summary>
        /// Start the game and then enter the main game loop
        /// </summary>
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

        /// <summary>
        /// Transfer a Ghost from one Player's inventory to the 
        /// other's.
        /// </summary>
        /// <param name="sender"> Player giving away the Ghost</param>
        /// <param name="ghost"> Ghost getting sent over.</param>
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

        /// <summary>
        /// Once the game loop is exited, show a message to indicate the game
        /// is over.
        /// </summary>
        private static void EndGame()
        {

            RenderInfo.ScreenMessage("GAME OVER!");

        }

    }
}