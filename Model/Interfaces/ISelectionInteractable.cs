namespace lp2_rec_ghosts.Model.Interfaces
{

    /// <summary>
    /// Interface to be implemented by objects that have logic to run
    /// when their interactions with another object are triggered by 
    /// something outside of the (me - Interactor) pair.
    /// </summary>
    public interface ISelectionInteractable
    {
        /// <summary>
        /// Interaction logic for interactions that are triggered by something
        /// other than the me - Interactor pair.
        /// </summary>
         public void OnSelectedInteraction();
    }
}