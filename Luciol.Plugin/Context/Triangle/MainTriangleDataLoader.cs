using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Luciol.Plugin.Context.Triangle
{
    public class MainTriangleDataLoader : ITriangleDataLoader
    {
        public MainTriangleDataLoader(string infoPath, string layersPath, IReadOnlyCollection<SemiInteractionData<float>> diagonal, Func<string, float[]> loader)
            => (InfoPath, LayersPath, Diagonal, Loader) = (infoPath, layersPath, diagonal, loader);

        public string InfoPath { init; get; }
        public string LayersPath { init; get; }
        public IReadOnlyCollection<SemiInteractionData<float>> Diagonal { init; get; }
        public Func<string,float[]> Loader { init; get; }

        public IMainTriangle<float> MainTriangle { set; get; }

        public Task<Color[][]> LoadDataAsync(int layer, int screenWidth, int screenHeight, int xOffset, int yOffset, int pixelSize, Func<(int X, int Y), float, Color> processCallback)
            => MainTriangle.LoadDataAsync(layer, screenWidth, screenHeight, xOffset, yOffset, pixelSize, processCallback);
    }
}
