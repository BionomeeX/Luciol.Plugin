namespace Luciol.Plugin.Context.EpistaticMap
{
    /// <summary>
    /// Interface used by triangle, allow to access data
    /// </summary>
    public interface ITriangleDataLoader
    {
        /// <summary>
        /// Get a value on the triangle
        /// </summary>
        /// <param name="layer">Layer to search on</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public float LoadData(int layer, int x, int y); // TODO: Change method name
    }
}
