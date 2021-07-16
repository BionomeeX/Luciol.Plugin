﻿using System.Collections.Generic;

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
        public void Load(string path, string dataFolderName);

        /// <summary>
        /// Data about the main triangle
        /// </summary>
        public IMainTriangle MainTriangle { get; }
        /// <summary>
        /// Information about all the plugins currently loaded
        /// </summary>
        public IReadOnlyCollection<APlugin> Plugins { get; }
        /// <summary>
        /// Used to access the save file
        /// </summary>
        public ISavedData SavedData { get; }
    }
}