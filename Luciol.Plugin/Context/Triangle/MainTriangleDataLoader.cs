using System;
using System.Collections.Generic;

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

        public float LoadData(int layer, int x, int y)
            => MainTriangle.LoadData(layer, x, y);
    }
}
