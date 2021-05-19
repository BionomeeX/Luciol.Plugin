using System;

namespace InterFace.Plugin.Event
{
    public sealed class AnnotationAddEventArgs : EventArgs
    {
        public AnnotationAddEventArgs(AAnnotation annotation)
            => Annotation = annotation;

        public AAnnotation Annotation { get; }
    }
}
