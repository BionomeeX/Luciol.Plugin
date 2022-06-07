using Luciol.Plugin.Context.Annotation;

namespace Luciol.Plugin.Context.EpistaticMap
{
    /// <summary>
    /// EpistaticMap that display interaction between the SNP
    /// </summary>
    /// <typeparam name="TIn">Type of the data displayed</typeparam>
    public interface IMainTriangle<TIn> : ITriangleDataLoader
    {
        /// <summary>
        /// Initialize the triangle
        /// </summary>
        /// <param name="infoPath">Main folder containing all triangle data</param>
        /// <param name="layerName">Name of the folder containing all layers</param>
        /// <param name="diagonal">Diagonal data associating values and positions</param>
        /// <param name="loader">Method used to load a file, return a set of data given a path</param>
        public void LoadData(string infoPath, string layerName,
            IReadOnlyCollection<SemiInteractionData<TIn>> diagonal,
            Func<string, TIn[]> loader);

        /// <summary>
        /// Get data about a SNP
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="layer"></param>
        public Task<SemiInteractionData<TIn>[]> GetSNPAsync(int pos, int layer);

        /// <summary>
        /// Get the value at the given point
        /// </summary>
        /// <param name="layer">Layer we search on</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public new TIn GetValue(int layer, int x, int y);
        /// <summary>
        /// Get the value of an annotation
        /// </summary>
        /// <param name="a">Annotation we want the value of</param>
        public TIn GetValue(CrossAnnotation a);
        /// <summary>
        /// Get the size of the triangle
        /// </summary>
        /// <param name="layer">Layer we want the size of</param>
        public int GetSize(int layer);

        /// <summary>
        /// Get all values on the diagonal
        /// </summary>
        public IReadOnlyCollection<SemiInteractionData<TIn>> GetDiagonal();
        /// <summary>
        /// Check if the given position is in the triangle
        /// </summary>
        /// <param name="posX">X position to check</param>
        /// <param name="posY">Y position to check</param>
        /// <param name="layer">Layer to check</param>
        public bool IsPositionValid(int posX, int posY, int layer);

        /// <summary>
        /// Maximum value in the triangle, doesn't include the diagonal
        /// Null on position triangle
        /// </summary>
        public float? MaxValue { get; }
        /// <summary>
        /// Maximum value in the diagonal
        /// Null on position triangle or if the triangle doesn't have a diagonal
        /// </summary>
        public float? MaxValueDiag { get; }

        /// <summary>
        /// Called before data are loaded
        /// </summary>
        public event EventHandler<EventArgs> OnDataLoading;
        /// <summary>
        /// Called after data are loaded
        /// </summary>
        public event EventHandler<EventArgs> OnDataLoaded;
        /// <summary>
        /// Called right after the resource manager clean old data
        /// </summary>
        public event EventHandler<EventArgs> OnDataCleaned;
    }
}
