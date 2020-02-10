using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Enums;

namespace lp2_rec_ghosts.Model.Board
{
    /// <summary>
    /// Base class for all the tiles of the game.
    /// </summary>
    public class CarpetTile : IBoardObject
    {

        public Colors MyColor {get; set;} 
        public Vector Position {get; set;}
        
        public CarpetTile(Colors color)
        {

            MyColor = color;

        }
        public CarpetTile(Colors color, Vector vec)
        {

            MyColor = color;
            this.Position = vec;

        }

        public CarpetTile(){}
    }
}