namespace lp2_rec_ghosts.Model.Ghosts
{
    public class RedGhost : GhostObject
    {
        protected override Colors BeatColor {get; set;} = Colors.BLUE;
        protected override Colors LoseToColor {get; set;} = Colors.YELLOW;

        public RedGhost(Player owner):base(owner) =>
            MyColor = Colors.RED; 


    }
}