using System;

namespace lp2_rec_ghosts.Model.Enums
{
    /// <summary>
    /// The colors that characterize every element on the board. 
    /// </summary>
    [Flags]
    public enum Colors
    {
        /// <remarks> Tiles that cannot be moved to and do not have a color 
        /// </remarks>
        NONE = 0,
        BLOCK = 1,
        RED = 2,
        YELLOW = 4,
        BLUE = 6,
        MIRROR = 8
        
    }
}