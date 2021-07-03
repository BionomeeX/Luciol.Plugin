namespace InterFace.Plugin
{
    public interface IAnnotation
    {
        /// <summary>
        /// First snip of the annotation (also equals to X position)
        /// </summary>
        public int Snip1 { get; }
        /// <summary>
        /// Second snip of the annotation (also equals to Y position)
        /// </summary>
        public int Snip2 { get; }
        /// <summary>
        /// Value of the annotation
        /// </summary>
        public double Value { get; }
    }
}
