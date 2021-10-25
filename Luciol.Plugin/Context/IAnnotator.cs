using Luciol.Plugin.Event;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luciol.Plugin.Context
{
    public interface IAnnotator
    {
        /// <summary>
        /// Add an annotation to the triangle
        /// </summary>
        /// <param name="annotation">Annotation to add</param>
        public Task AddAnnotationAsync(int posX, int posY, int layer, AnnotationType type);
        /// <summary>
        /// Remove an annotation from the triangle
        /// </summary>
        /// <param name="posX">X position of the annotation</param>
        /// <param name="posY">Y position of the annotation</param>
        /// <param name="layer">Layer the annotation is in</param>
        public void RemoveAnnotation(int posX, int posY, int layer);
        /// <summary>
        /// Check is an annotation is at the given position
        /// </summary>
        /// <param name="posX">X position to check</param>
        /// <param name="posY">Y position to check</param>
        /// <param name="layer">Layer to check</param>
        /// <returns></returns>
        public bool DoesContainsAnnotation(int posX, int posY, int layer, AnnotationType type);
        /// <summary>
        /// Get all annotations already placed
        /// </summary>
        public IReadOnlyCollection<Annotation> GetAnnotations();
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
