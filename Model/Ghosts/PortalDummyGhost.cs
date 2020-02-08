namespace lp2_rec_ghosts.Model.Ghosts
{

    /// <summary>
    /// Dummy Ghosts are not visible but are still interacted with and
    /// move. They act as the Portals, being always in "front" of them.
    /// And trigger the escape of a same colored Ghost it touches.
    /// </summary>
    public class PortalDummyGhost : GhostObject
    {
        // It wins against the ones it lets escape. What a good friend.
        protected override Colors BeatColor {get; set;}

        // It "Loses" to anyone it doesn't teleport.
        protected override Colors LoseToColor {get; set;} = 
            Colors.RED | Colors.BLUE | Colors.YELLOW;

        public PortalDummyGhost(Colors myColor, Player owner = null):
            base(owner)
            {
                MyColor = myColor;
                BeatColor = MyColor;
                LoseToColor &= ~MyColor; 


            }
                 

    }
}