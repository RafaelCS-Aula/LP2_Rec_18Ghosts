using lp2_rec_ghosts.Model.Interfaces;

namespace lp2_rec_ghosts.Model
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