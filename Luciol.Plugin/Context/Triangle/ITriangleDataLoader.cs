using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Luciol.Plugin.Context.Triangle
{
    public interface ITriangleDataLoader
    {
        /// <summary>
        /// Display a triangle on the screen
        /// </summary>
        /// <param name="layer">Zoom layer we are in</param>
        /// <param name="screenWidth">Width of the screen</param>
        /// <param name="screenHeight">Height of the screen</param>
        /// <param name="xOffset">X offset of the camera on the screen</param>
        /// <param name="yOffset">Y offset of the camera on the screen</param>
        /// <param name="pixelSize">Current size of a pixel</param>
        /// <param name="processCallback">
        /// Method used to calculate the value of a point
        /// Takes:
        ///  - X and Y coordinate
        ///  - Current point value
        ///  - Max possible point value
        /// </param>
        /// <returns>Buffer to render on screen</returns>
        public Task<int[][]> LoadDataAsync(int layer, int screenWidth, int screenHeight, int xOffset, int yOffset, int pixelSize, Func<(int X, int Y), float, int> processCallback);
    }
}
