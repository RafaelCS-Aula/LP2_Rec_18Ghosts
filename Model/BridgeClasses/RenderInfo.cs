using lp2_rec_ghosts.Model.Interfaces;
using System.Collections.Generic;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Ghosts;

namespace lp2_rec_ghosts.Model.BridgeClasses
{
    /// <summary>
    /// Class that will enter contact with the classes outside the Model
    /// with the purpose of giving out info that should be rendered on screen.
    /// </summary>
    public static class RenderInfo 
    {

        /// <summary>
        /// Outsider class that handles the rendering.
        /// </summary>
        public static IRenderer OutsideRenderer {get; set;}

        /// <summary>
        /// Call the OutsideRenderer's DrawMessage() method.
        /// </summary>
        /// <param name="msg"> Message to print. </param>
        public static void ScreenMessage(string msg)
        {

            OutsideRenderer.DrawMessage(msg);

        }

        /// <summary>
        /// Call the OutsideRenderer's DrawGhostList() method.
        /// </summary>
        /// <param name="list"> Player's Ghost inventory.</param>
        public static void UpdateGhostListing(GhostObject[][] list)
        {

            OutsideRenderer.DrawGhostList(list);

        }

        /// <summary>
        /// Call the OutsideRenderer's DrawBoard() method.
        /// </summary>
        /// <param name="board"> The game board in the current state to be
        /// rendered on screen. </param>
        public static void UpdateBoardDraw(
            Dictionary<Vector, IBoardObject[]> board)
            {

                OutsideRenderer.DrawBoard(board);

            }

    }
}