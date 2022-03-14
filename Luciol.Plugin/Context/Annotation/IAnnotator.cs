using Luciol.Plugin.Event;

namespace Luciol.Plugin.Context.Annotation
{
    /// <summary>
    /// Tool used to manage the annotations
    /// </summary>
    public interface IAnnotator
    {
        /// <summary>
        /// Add an annotation to the triangle
        /// </summary>
        /// <param name="annotation">Annotation to add</param>
        /// <returns>The newly created annotation, or the current one if already exists</returns>
        public IAnnotation AddAnnotation(IAnnotation annotation);
        /// <summary>
        /// Remove an annotation from the triangle
        /// If it doesn't exist, nothing happen
        /// </summary>
        /// <param name="annotation">Annotation to remove</param>
        /// <param name="layer">Layer the annotation is in</param>
        public void RemoveAnnotation(IAnnotation annotation);
        /// <summary>
        /// Get all annotations already placed
        /// </summary>
        public IReadOnlyCollection<IAnnotation> GetAnnotations();
        /// <summary>
        /// Called when an annotation is added
        /// </summary>
        public event EventHandler<AnnotationEventArgs> OnAnnotationAdd;
        /// <summary>
        /// Called when an annotation is removed
        /// </summary>
        public event EventHandler<AnnotationEventArgs> OnAnnotationRemove;
    }
}
