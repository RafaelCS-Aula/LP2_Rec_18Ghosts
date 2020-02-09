namespace lp2_rec_ghosts.Model.Interfaces
{
    /// <summary>
    /// Interface to be implemented by class outside of Model that
    /// handles the rendering.    
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Draw a simple message on the screen.
        /// </summary>
        /// <param name="message"> Text to display.static </param>
        public void DrawMessage(string message);

    }
}