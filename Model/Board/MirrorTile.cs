using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.Enums;

namespace lp2_rec_ghosts.Model.Board
{
    /// <summary>
    /// Class representing the mirror tiles on the board.
    /// </summary>
    public class MirrorTile : CarpetTile, ISelectionInteractable
    {
        public MirrorTile() => MyColor = Colors.MIRROR;

        /// <summary>
        /// Change how the gameBoard will chose the valid tiles 
        /// this turn to Drop placement.
        /// </summary>
        public void OnSelectedInteraction()
        {
            GameController.GBoard.DropPlacement = true;

        }
        
    }
}