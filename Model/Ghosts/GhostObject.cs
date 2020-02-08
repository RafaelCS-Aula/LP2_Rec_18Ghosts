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

        public GhostObject(Vector position, Player owner)
        {
            this.Position = position;
            this.Owner = owner;
        }

        public void OnInstantInteraction()
        {

            

        }

        public void Fight()
        {
            return;


        }

    }
}