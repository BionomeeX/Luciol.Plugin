using Luciol.Plugin.Preference.Global;
using System.Collections.Generic;

namespace Luciol.Plugin.Context
{
    public interface IContext
    {
        /// <summary>
        /// Create a new instance of the context
        /// </summary>
        /// <param name="path">Path where the file must be saved</param>
        /// <param name="dataFolderName">Name of the folder containing triangle data</param>
        /// <param name="plugins">List of plugins to use</param>
        public void Create(string path, string dataFolderName, IReadOnlyCollection<APlugin> plugins);

        /// <summary>
        /// Create a context from an existing save file
        /// </summary>
        /// <param name="path">Path to the existing save file</param>
        /// <param name="dataFolderName">Name of the folder containing triangle data</param>
        public void Load(string path);

        /// <summary>
        /// Data about the main triangle
        /// </summary>
        public IMainTriangle<float> SNPTriangle { get; }
        public IMainTriangle<uint> PositionTriangle { get; }
        /// <summary>
        /// Information about all the plugins currently loaded
        /// </summary>
        public IReadOnlyCollection<APlugin> Plugins { get; }
        /// <summary>
        /// Used to access the save file
        /// </summary>
        public ISavedData SavedData { get; }

        /// <summary>
        /// Manage the annotations
        /// </summary>
        public IAnnotator Annotator { get; }

        /// <summary>
        /// Global settings of the application
        /// </summary>
        public GlobalSettings GlobalSettings { get; }

        /// <summary>
        /// Information shared between all triangles
        /// </summary>
        public ITriangleInstance TInfo { get; }
    }
}
