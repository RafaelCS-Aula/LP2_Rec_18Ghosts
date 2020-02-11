using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model.GameTypes;
using lp2_rec_ghosts.Model.Enums;
using lp2_rec_ghosts.Model.Board;
using lp2_rec_ghosts.Model.BridgeClasses;

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
        public Player Owner {get; protected set;}

        public bool InDungeon {get; set;} = false;

        /// <summary>
        /// The Ghost this Ghost is fighting with.
        /// </summary>
        protected GhostObject enemy;
        

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
        /// Place the Ghost in a new grid position. After checking if there is
        /// anything to fight.
        /// </summary>
        /// <param name="newPosition"> The Ghost's new grid position</param>
        public virtual void Move(Vector newPosition)
        {
            IBoardObject[] gridSpace;
            GameBoard.Board.TryGetValue(newPosition, out gridSpace );

            IInstantInteractable possibleGhost = gridSpace[1] as GhostObject;
            IInstantInteractable possiblePortal 
                = gridSpace[2] as PortalDummyGhost; 

            possibleGhost?.OnInstantInteraction(this);
            
            if(possibleGhost != null) OnInstantInteraction(possibleGhost);

            possiblePortal?.OnInstantInteraction(this);

            // Since Ghosts go to 0,0 when sent to dungeon
            // we can check their status like this.
            if(!InDungeon)
                Position = newPosition;
            GameController.GBoard.UpdateGhostOnBoard(this);

        } 
        
        public virtual void Move(){}

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
            GameController.GBoard.RotatePortal(MyColor);
            Position = new Vector(0,0);

        }

        /// <summary>
        /// Method that gathers the positions that are orthogonally adjacent
        /// to this Ghost.
        /// </summary>
        /// <returns> A vector array of 4 with it's neighbours,
        /// starting from the top one and going clock-wise.</returns>
        public virtual Vector[] Neighbours()
        {
            Vector[] neighbours = new Vector[4];

            neighbours[0] = Position + new Vector(0,1);
            neighbours[1] = Position + new Vector(1,0);
            neighbours[2] = Position - new Vector(0,1);
            neighbours[3] = Position - new Vector(1,0);

            return neighbours;

        }

        /// <summary>
        /// Call the owning player's method to bust a ghost that isn't
        /// this one out of the dungeon.
        /// </summary>
        /// <param name="friend"> The ghost being busted.null </param>
        protected virtual void EscapeFriend(GhostObject friend)
        {
            Owner.BustGhost(friend, true);
        }

    }
}