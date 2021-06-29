﻿using System;

namespace InterFace.Plugin.Event
{
    public sealed class AnnotationEventArgs : EventArgs
    {
        public AnnotationEventArgs(IAnnotation annotation)
            => Annotation = annotation;

        public IAnnotation Annotation { get; }
    }
}