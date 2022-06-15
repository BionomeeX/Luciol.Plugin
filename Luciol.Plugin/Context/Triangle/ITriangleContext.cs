using Luciol.Plugin.Preference;

namespace Luciol.Plugin.Context.Triangle
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
        public string MainTriangle { set; get; }
        public string SubTriangle { set; get; }
        public GradientPreference MainGradient(string key);
        public GradientPreference DiagonalGradient(string key);
        /// <summary>
        /// Get the raw triangle display
        /// </summary>
        /// <param name="layer">Layer of the triangle we currently are on</param>
        /// <param name="screenWidth">Width of the display</param>
        /// <param name="screenHeight">Height of the display</param>
        /// <param name="xOffset">X offset to apply</param>
        /// <param name="yOffset">Y offset to apply</param>
        /// <returns>Triangle colors</returns>
        public Task<int[][]> GetScreenBufferAsync(int layer, int screenWidth, int screenHeight, int xOffset, int yOffset);
    }
}
