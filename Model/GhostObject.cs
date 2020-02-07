using lp2_rec_ghosts.Model.Interfaces;

namespace lp2_rec_ghosts.Model
{
    public abstract class GhostObject: BoardObject, IInstantInteractable 
    {



        public void OnInstantInteraction()
        {

            Fight();

        }

        public void Fight()
        {

            

        }

    }
}