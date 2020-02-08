namespace lp2_rec_ghosts.Model.Ghosts
{
    public class YellowGhost : GhostObject
    {

        protected override Colors BeatColor {get; set;} = Colors.RED;
        protected override Colors LoseToColor {get; set;} = Colors.BLUE;

        public YellowGhost(Player owner):base(owner)
            => MyColor = Colors.YELLOW; 


        
    }
}