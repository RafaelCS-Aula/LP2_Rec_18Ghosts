using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Enums;
using lp2_rec_ghosts.Model.BridgeClasses;

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

        /// <summary>
        /// If the dummy wins a fight, it'll make the enemy teleport away.
        /// </summary>
        protected override void WinFight()
        {

            EscapeFriend(enemy);

        }

        /// <summary>
        /// Don't do anything if Ghost loses fight.
        /// </summary>
        protected override void LoseFight(){}
                 
        /// <summary>
        /// Apply a translation to the dummy ghost so to move it 90ª
        /// clockwise.
        /// </summary>
        public override void Move()
        {   
            /* Rotating a 2D Vector by 90ª:
            *  multiplying X by -1 and then switching the axis'.
            */

            Vector newPosition =
                new Vector(Position.Y, -Position.X);

            Position = newPosition;
            GameController.GBoard.UpdateGhostOnBoard(this);

        }

    }
}