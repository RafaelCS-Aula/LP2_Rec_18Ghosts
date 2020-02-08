namespace lp2_rec_ghosts.Model.Ghosts
{
    /// <summary>
    /// Yellow Ghosts, they lose to Blues and Beat Reds.
    /// </summary>
    public class YellowGhost : GhostObject
    {

        protected override Colors BeatColor {get; set;} = Colors.RED;
        protected override Colors LoseToColor {get; set;} = Colors.BLUE;

        public YellowGhost(Player owner):base(owner)
            => MyColor = Colors.YELLOW; 


        
    }
}