using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model;

namespace lp2_rec_ghosts.Model.Ghosts
{
    /// <summary>
    /// Ghosts fight, move and are owned by a Player.
    /// </summary>
    public abstract class GhostObject: IBoardObject, IInstantInteractable 
    {
        /// <summary>
        /// Colors that this Ghost wins in a fight with.
        /// </summary>
        /// <value> Color value to be compared with.</value>
        protected abstract Colors BeatColor {get; set;}

        /// <summary>
        /// Colors that this Ghost loses in a fight with.
        /// </summary>
        /// <value> Color value to be compared with. </value>
        protected abstract Colors LoseToColor {get; set;}

        /// <summary>
        ///  This Ghost's color value.
        /// </summary>
        /// <value> A value from the Colors enum. </value>
        public Colors MyColor {get; set;}

        /// <summary>
        /// This Ghost's grid position.
        /// </summary>
        /// <value> A Vector with an X and Y components. </value>
        public Vector Position {get; set;}
        
        /// <summary>
        ///  The Player currently capable of controlling this Ghost.
        /// </summary>
        /// <value> A Player object </value>
        protected Player Owner {get; set;}

        /// <summary>
        /// The Ghost this Ghost is fighting with.
        /// </summary>
        private GhostObject enemy;

        /// <summary>
        /// Abstract constructor of the Ghost super class.
        /// </summary>
        /// <param name="owner"> The Player that currently controls this Ghost.
        /// </param>
        public GhostObject(Player owner)
        {
            this.Owner = owner;
        }

        /// <summary>
        /// This Ghost has found another one to fight with!
        /// </summary>
        /// <param name="other"> The other Ghost </param>
        public void OnInstantInteraction(IInstantInteractable other)
        {
            enemy = (other as GhostObject);
            if(enemy.MyColor == BeatColor) WinFight();
            else if(enemy.MyColor == LoseToColor) LoseFight();
            
        }

        /// <summary>
        /// Place the Ghost in a new grid position.
        /// </summary>
        /// <param name="newPosition"> The Ghost's new grid position</param>
        public virtual void Move(Vector newPosition)
        {


            // TODO: DECIDE IF THE GHOST DOES THIS OR SOMETHIGN ELSE

        }

        /// <summary>
        /// The Ghost has won his fight with another Ghost.
        /// </summary>
        protected virtual void WinFight(){}

        /// <summary>
        /// The Ghost has lost a fight with another Ghost.
        /// </summary>
        protected virtual void LoseFight()
        {

            Owner.SendGhostToDungeon(this);
            Position = new Vector(0,0);

        }


    }
}