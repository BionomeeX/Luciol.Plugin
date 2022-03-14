namespace Luciol.Plugin.Context.Triangle
{
    /// <summary>
    /// Data loader for triangle made in layers
    /// </summary>
    public class MainTriangleDataLoader : ITriangleDataLoader
    {
        /// <param name="infoPath">Main folder containing all triangle data</param>
        /// <param name="layerName">Name of the folder containing all layers</param>
        /// <param name="diagonal">Diagonal data associating values and positions</param>
        /// <param name="loader">Method used to load a file, return a set of data given a path</param>
        public MainTriangleDataLoader(string infoPath, string layerName, IReadOnlyCollection<SemiInteractionData<float>> diagonal, Func<string, float[]> loader)
            => (InfoPath, LayerName, Diagonal, Loader) = (infoPath, layerName, diagonal, loader);

        /// <summary>
        /// Main folder containing all triangle data
        /// </summary>
        public string InfoPath { init; get; }
        /// <summary>
        /// Folder containing all layers
        /// </summary>
        public string LayerName { init; get; }
        /// <summary>
        /// Diagonal data associating values and positions
        /// </summary>
        public IReadOnlyCollection<SemiInteractionData<float>> Diagonal { init; get; }
        /// <summary>
        /// Method used to load a file, return a set of data given a path
        /// </summary>
        public Func<string,float[]> Loader { init; get; }

        /// <summary>
        /// Main triangle information
        /// </summary>
        public IMainTriangle<float> MainTriangle { set; get; }

        /// <inheritdoc/>
        public float LoadData(int layer, int x, int y)
            => MainTriangle.LoadData(layer, x, y);
    }
}
