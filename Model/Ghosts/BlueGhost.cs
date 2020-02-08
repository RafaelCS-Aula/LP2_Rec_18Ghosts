namespace lp2_rec_ghosts.Model.Ghosts
{
    public class BlueGhost : GhostObject
    {

        protected override Colors BeatColor {get; set;} = Colors.YELLOW;
        protected override Colors LoseToColor {get; set;} = Colors.RED;

        public BlueGhost(Vector position, Player owner):base(position, owner) =>
            MyColor = Colors.BLUE; 



    }
}