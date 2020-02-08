using lp2_rec_ghosts.Model.Interfaces;
using lp2_rec_ghosts.Model;

namespace lp2_rec_ghosts.Model.Ghosts
{
    public abstract class GhostObject: IBoardObject, IInstantInteractable 
    {
        protected abstract Colors BeatColor {get; set;}
        protected abstract Colors LoseToColor {get; set;}

        public Colors MyColor {get; set;}
        public Vector Position {get; set;}
        
        protected Player Owner {get; set;}

        private GhostObject enemy;

        public GhostObject(Player owner)
        {
            this.Owner = owner;
        }

        public void OnInstantInteraction(IInstantInteractable other)
        {
            enemy = (other as GhostObject);
            if(enemy.MyColor == BeatColor) WinFight();
            else if(enemy.MyColor == LoseToColor) LoseFight();
            

        }

        public virtual void Move(Vector newPosition)
        {




        }

        protected virtual void WinFight(){}
        protected virtual void LoseFight()
        {

            Owner.SendGhostToDungeon(this);
            Position = new Vector(0,0);

        }


    }
}