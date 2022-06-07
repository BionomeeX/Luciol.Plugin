namespace Luciol.Plugin.Context.EpistaticMap
{
    /// <summary>
    /// Data about all the triangles
    /// </summary>
    public interface ITriangleContext
    {
        /// <summary>
        /// Returns the names of all the available triangles
        /// </summary>
        public IEnumerable<string> GetOptions();
        /// <summary>
        /// Enable a triangle to be displayed
        /// </summary>
        /// <param name="key">Name of the triangle to display</param>
        public void Enable(string key);
        /// <summary>
        /// Hide a triangle from the display
        /// </summary>
        /// <param name="key">Name of the triangle to hide</param>
        public void Disable(string key);
        /// <summary>
        /// Is a triangle displayed
        /// </summary>
        /// <param name="key">EpistaticMap to check</param>
        public bool IsEnabled(string key);
        /// <summary>
        /// Get the raw triangle display
        /// </summary>
        /// <param name="layer">Layer of the triangle we currently are on</param>
        /// <param name="screenWidth">Width of the display</param>
        /// <param name="screenHeight">Height of the display</param>
        /// <param name="xOffset">X offset to apply</param>
        /// <param name="yOffset">Y offset to apply</param>
        /// <returns>EpistaticMap colors</returns>
        public Task<int[][]> GetScreenBufferAsync(int layer, int screenWidth, int screenHeight, int xOffset, int yOffset);
    }
}
