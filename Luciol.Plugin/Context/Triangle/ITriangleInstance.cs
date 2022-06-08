namespace Luciol.Plugin.Context.Triangle
{
    /// <summary>
    /// Represent a triangle display
    /// </summary>
    public interface ITriangleInstance
    {
        /// <summary>
        /// Size of a point in pixel
        /// </summary>
        public int PixelSize { get; }
        /// <summary>
        /// Current layer to display
        /// </summary>
        public int CurrentZoom { set; get; }
        /// <summary>
        /// Move on the triangle
        /// </summary>
        /// <param name="x">X target</param>
        /// <param name="y">Y target</param>
        public void Move(double x, double y);
    }
}
