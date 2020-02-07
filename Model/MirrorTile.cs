using lp2_rec_ghosts.Model.Interfaces;

namespace lp2_rec_ghosts.Model
{
    public class MirrorTile : BoardObject, ISelectionInteractable
    {
        public MirrorTile() => Color = Colors.MIRROR;

        public void OnSelectedInteraction()
        {
            //TODO: change movement type to DROP

        }
        
    }
}