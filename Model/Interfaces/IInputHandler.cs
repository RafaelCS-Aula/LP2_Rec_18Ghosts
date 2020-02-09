namespace lp2_rec_ghosts.Model.Interfaces
{
    /// <summary>
    /// Interface to be implemented by class outside of Model that
    /// handles the input.
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// Get 2 floats from the outside class to be used as input once inside
        /// the model.
        /// </summary>
        /// <param name="x">The wanted X component of the Vector</param>
        /// <param name="y">The wanted Y component of the Vector</param>
        public void AwaitVectorInput(out float x, out float y);


    }
}