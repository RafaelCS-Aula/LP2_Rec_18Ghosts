using lp2_rec_ghosts.Model.Interfaces;

namespace lp2_rec_ghosts.Model.BridgeClasses
{
    /// <summary>
    /// Class that will enter contact with the classes outside the Model
    /// with the purpose of giving out info that should be rendered on screen.
    /// </summary>
    public static class RenderInfo 
    {

        /// <summary>
        /// Outsider class that handles the rendering.
        /// </summary>
        public static IRenderer OutsideRenderer {get; set;}

        /// <summary>
        /// Call the OutsideRenderer's DrawMessage() method.
        /// </summary>
        /// <param name="msg"> Message to print. </param>
        public static void ScreenMessage(string msg)
        {

            OutsideRenderer.DrawMessage(msg);

        }

    }
}