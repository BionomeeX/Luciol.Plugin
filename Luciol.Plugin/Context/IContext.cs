﻿using Luciol.Plugin.Context.Annotation;
using Luciol.Plugin.Context.Triangle;
using Luciol.Plugin.Core;
using Luciol.Plugin.Preference.Global;

namespace Luciol.Plugin.Context
{
    /// <summary>
    /// Contains instances about everything needed to interact with Luciol
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Create a new instance of the context
        /// </summary>
        /// <param name="path">Path where the save file will be written</param>
        /// <param name="dataFolderName">Folder containing triangle data</param>
        /// <param name="plugins">List of plugins to use</param>
        public void Create(string path, string dataFolderName, IReadOnlyCollection<APlugin> plugins);

        /// <summary>
        /// Create a context from an existing save file
        /// </summary>
        /// <param name="path">Path to the existing save file</param>
        /// <param name="dataFolderName">Name of the folder containing triangle data</param>
        public void Load(string path);

        /// <summary>
        /// Data about thetriangle containing the positions
        /// </summary>
        public IMainTriangle<(long, long)> PositionTriangle { get; }
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
        /// <summary>
        /// Informations about all triangle
        /// </summary>
        public ITriangleContext TriangleContext { get; }
    }
}
