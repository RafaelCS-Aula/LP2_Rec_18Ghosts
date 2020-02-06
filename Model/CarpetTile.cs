namespace lp2_rec_ghosts.Model
{
    public class CarpetTile : BoardObject
    {
        public CarpetTile(Colors color)
        {

            this.Color = color;

        }
        public CarpetTile(Colors color, Vector vec)
        {

            this.Color = color;
            this.Position = vec;

        }
    }
}