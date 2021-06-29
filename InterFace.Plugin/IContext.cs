using System.Collections.Generic;

namespace InterFace.Plugin
{
    public interface IContext
    {
        public void Load(string path);

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
