using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luciol.Plugin.Context.Triangle
{
    public interface ITriangleContext
    {
        public IEnumerable<string> GetOptions();
        public void Enable(string key);
        public void Disable(string key);
        public Task<int[][]> GetScreenBufferAsync(int layer, int screenWidth, int screenHeight, int xOffset, int yOffset, int pixelSize);
    }
}
