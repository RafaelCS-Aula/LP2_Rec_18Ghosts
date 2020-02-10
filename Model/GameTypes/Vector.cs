namespace lp2_rec_ghosts.Model.GameTypes
{
    /// <summary>
    /// Base struct for positions and translations.
    /// </summary>
    public struct Vector
    {
        /// <summary>
        /// Horizontal component of the Vector
        /// </summary>
        public int X {get; set;}

        /// <summary>
        /// Vertical component of the Vector
        /// </summary>
        public int Y {get; set;}

        /// <summary>
        /// Describes movements and positions on the board.
        /// </summary>
        /// <param name="x"> Horizontal component of the Vector </param>
        /// <param name="y"> Vertical component of the Vector </param>
        public Vector(int x, int y)
        {

            X = x;
            Y = y;

        }

        /// <summary>
        /// Method to quickly check if the current vector is a diagonal
        /// translation from its origin.
        /// </summary>
        /// <returns> Whether either the X and Y components are 
        /// diferent than 0.</returns>
        public bool isDiagonal() => Y != 0 && X != 0;
            
        /// <summary>
        /// Override to define the sum of 2 Vectors.
        /// </summary>
        /// <param name="a"> First input </param>
        /// <param name="b"> Second input </param>
        /// <returns> A Vector with its components as sums of the inputs
        /// </returns>
        public static Vector operator+ (Vector a, Vector b) => 
            new Vector(a.X + b.X, a.Y + b.Y);

        /// <summary>
        /// Override to define the subtraction of 2 Vectors.
        /// </summary>
        /// <param name="a"> First input </param>
        /// <param name="b"> Second input </param>
        /// <returns> Vector with its components as the difference 
        /// between inputs </returns>
        public static Vector operator- (Vector a, Vector b) => 
            new Vector(a.X - b.X, a.Y - b.Y);
 
    }



}