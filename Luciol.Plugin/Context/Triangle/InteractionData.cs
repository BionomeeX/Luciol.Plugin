namespace Luciol.Plugin.Context.EpistaticMap
{
    /// <summary>
    /// Data about an interaction
    /// </summary>
    /// <typeparam name="T">Type of the value</typeparam>
    public record InteractionData<T>
    {
        /// <summary>
        /// Value on the given point
        /// </summary>
        public T Value { init; get; }
        /// <summary>
        /// Chpos / 100 is the chromosome
        /// Chpos % 100 is the position
        /// </summary>
        public uint ChPos { init; get; } // TODO: Split that into 2 variables
    }
}
