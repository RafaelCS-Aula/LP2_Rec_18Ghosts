namespace lp2_rec_ghosts.Model.Ghosts
{
                /// <summary>
                /// DUMMY THICC LMAO
                /// </summary>
    public class PortalDummyGhost : GhostObject
    {
        
        protected override Colors BeatColor {get; set;}
        protected override Colors LoseToColor {get; set;} = 
            Colors.RED | Colors.BLUE | Colors.YELLOW;

        public PortalDummyGhost(Vector position,Colors myColor, 
        Player owner = null):
            base(position, owner)
            {
                MyColor = myColor;
                BeatColor = MyColor;
                LoseToColor &= ~MyColor; 


            }
                 

    }
}