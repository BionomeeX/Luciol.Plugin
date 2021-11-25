﻿using Luciol.Plugin.Context.Annotation;
using System;

namespace Luciol.Plugin.Event
{
    /// <summary>
    /// Represent an interation with an annotation
    /// </summary>
    public sealed class AnnotationEventArgs : EventArgs
    {
        public AnnotationEventArgs(CrossAnnotation annotation)
            => Annotation = annotation;

        public CrossAnnotation Annotation { get; }
    }
}
