using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Enums;

namespace lp2_rec_ghosts.Model.Interfaces
{
    /// <summary>
    /// Interface for any class that represents an object that would be
    /// on the board, or the board itself.
    /// </summary>
    public interface IBoardObject
    {
        /// <summary>
        /// this object's grid position.
        /// </summary>
        /// <value> A Vector with an X and Y components. </value>
        Vector Position {get; set;}

        /// <summary>
        /// The obejct's color, can also be its type such as Mirror or Block.
        /// </summary>
        /// <value> The Colors value, necessary for comaprisons between objects
        ///  </value>
        Colors MyColor {get; set;}
    }
}