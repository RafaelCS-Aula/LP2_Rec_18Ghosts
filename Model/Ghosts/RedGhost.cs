namespace lp2_rec_ghosts.Model.Ghosts
{
    public class RedGhost : GhostObject
    {
        protected override Colors BeatColor {get; set;} = Colors.BLUE;
        protected override Colors LoseToColor {get; set;} = Colors.YELLOW;

        public RedGhost(Vector position, Player owner):base(position, owner) =>
            MyColor = Colors.RED; 


    }
}