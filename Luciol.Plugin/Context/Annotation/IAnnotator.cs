﻿using Luciol.Plugin.Event;
using System;
using System.Collections.Generic;

namespace Luciol.Plugin.Context.Annotation
{
    public interface IAnnotator
    {
        /// <summary>
        /// Add an annotation to the triangle
        /// </summary>
        /// <param name="annotation">Annotation to add</param>
        /// <returns>The newly created annotation, or the current one if already exists</returns>
        public IAnnotation AddAnnotation(int posX, int posY, int layer, IAnnotationFactory factory);
        /// <summary>
        /// Remove an annotation from the triangle
        /// </summary>
        /// <param name="posX">X position of the annotation</param>
        /// <param name="posY">Y position of the annotation</param>
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
