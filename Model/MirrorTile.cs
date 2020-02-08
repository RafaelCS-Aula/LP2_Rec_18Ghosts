using lp2_rec_ghosts.Model.Interfaces;

namespace lp2_rec_ghosts.Model
{
    public class MirrorTile : CarpetTile, ISelectionInteractable
    {
        public MirrorTile() => MyColor = Colors.MIRROR;

        public void OnSelectedInteraction()
        {
            //TODO: change movement type to DROP

        }
        
    }
}