using System.Collections.Generic;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Ghosts;

namespace lp2_rec_ghosts.Model.Interfaces
{
    /// <summary>
    /// Interface to be implemented by class outside of Model that
    /// handles the rendering.    
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Draw a simple message on the screen.
        /// </summary>
        /// <param name="message"> Text to display.static </param>
        void DrawMessage(string message);

        /// <summary>
        /// Draw the list of Ghosts of the current Player's turn.
        /// </summary>
        /// <param name="ghostList"></param>
        void DrawGhostList(GhostObject[][] ghostList);

        /// <summary>
        /// Draw the Board, tiles and ghosts.
        /// </summary>
        /// <param name="board"> The game board in the state to be drawn 
        /// </param>
        void DrawBoard(Dictionary<Vector, IBoardObject[]> board);

    }
}