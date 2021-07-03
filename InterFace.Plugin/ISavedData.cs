namespace InterFace.Plugin
{
    public interface ISavedData
    {
        /// <summary>
        /// Call this when you need to save anything
        /// </summary>
        /// <remarks>
        /// You won't need to call that manually except if you manually do modification to the save files
        /// </remarks>
        public void Save();
    }
}
