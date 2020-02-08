using System;

namespace lp2_rec_ghosts.Model
{
    /// <summary>
    /// The colors that characterize every element on the board. 
    /// </summary>
    public enum Colors
    {
        /// <remarks> Tiles that cannot be moved to and do not have a color 
        /// </remarks>
        BLOCK = 0,
        RED = 1,
        YELLOW = 2,
        BLUE = 4,
        MIRROR = 6
        
    }
}