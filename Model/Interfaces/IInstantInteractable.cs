namespace lp2_rec_ghosts.Model.Interfaces
{
    /// <summary>
    /// Interface to be implemented by any object that has its 
    /// interaction logic happen as soon as it has something to
    /// interact with.
    /// </summary>
    public interface IInstantInteractable
    {
        /// <summary>
        /// Interaction logic for itneractions that happen the moment the object
        /// has something to interact with.
        /// </summary>
        public void OnInstantInteraction();
    }
}