using Luciol.Plugin.Preference;

namespace Luciol.Plugin.Context.Annotation
{
    /// <summary>
    /// Annotations are a way to mark data on Luciol
    /// </summary>
    public interface IAnnotation
    {
        /// <summary>
        /// Layer the annotation was placed on
        /// </summary>
        public int Layer { get; }
        /// <summary>
        /// Name given to the annotation
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Name of the plugin that the annotation is from
        /// </summary>
        public string Sender { get; }
        /// <summary>
        /// How the annotation will be drawn on the main triangle
        /// </summary>
        public DrawType DrawType { get; }
        /// <summary>
        /// Displayed color of the annotation on the triangle
        /// </summary>
        public Color Color { get; }
        /// <summary>
        /// High priority annotations are displayed on top of the lower ones
        /// </summary>
        public Priority Priority { get; }
        /// <summary>
        /// What kind of annotation it is
        /// </summary>
        public AnnotationType Type { get; }
        /// <summary>
        /// Is the annotation displayed on the triangle
        /// </summary>
        public bool IsActive { set; get; }
        public string ID { get; }
    }
}
