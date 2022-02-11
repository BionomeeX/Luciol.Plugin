using Luciol.Plugin.Preference;

namespace Luciol.Plugin.Context.Annotation
{
    public interface IAnnotation
    {
        /// <summary>
        /// Layer the annotation was placed on
        /// </summary>
        public int Layer { get; }
        /// <summary>
        /// Type of the annotation
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Plugin that annotation is from
        /// </summary>
        public string Sender { get; }
        /// <summary>
        /// How the annotation will be drawn on the main triangle
        /// </summary>
        public DrawType DrawType { get; }
        public Color Color { get; }
        public Priority Priority { get; }
        public AnnotationType Type { get; }
        public bool IsActive { set; get; }
    }
}
