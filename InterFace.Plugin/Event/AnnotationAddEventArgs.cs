using System;

namespace InterFace.Plugin.Event
{
    public sealed class AnnotationAddEventArgs : EventArgs
    {
        public AnnotationAddEventArgs(IAnnotation annotation)
            => Annotation = annotation;

        public IAnnotation Annotation { get; }
    }
}
