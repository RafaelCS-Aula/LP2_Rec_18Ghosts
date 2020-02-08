namespace lp2_rec_ghosts.Model.Ghosts
{
    /// <summary>
    /// Red Ghosts, lose to Yellows and beat Blues.
    /// </summary>
    public class RedGhost : GhostObject
    {
        protected override Colors BeatColor {get; set;} = Colors.BLUE;
        protected override Colors LoseToColor {get; set;} = Colors.YELLOW;

        public RedGhost(Player owner):base(owner) =>
            MyColor = Colors.RED; 


    }
}