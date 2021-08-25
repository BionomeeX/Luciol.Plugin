using Luciol.Plugin.Context;
using System;

namespace Luciol.Plugin.Event
{
    /// <summary>
    /// Represent an interation with an annotation
    /// </summary>
    public sealed class AnnotationEventArgs : EventArgs
    {
        public AnnotationEventArgs(Annotation annotation)
            => Annotation = annotation;

        public Annotation Annotation { get; }
    }
}
