using InterFace.Plugin.Event;
using System;
using System.Collections.Generic;

namespace InterFace.Plugin
{
    public interface IMainTriangle
    {
        public void AddAnnotation(IAnnotation annotation);
        public void RemoveAnnotation(int posX, int posY, int layer);
        public bool DoesContainsAnnotation(int posX, int posY, int layer);
        public IReadOnlyCollection<IAnnotation> GetAnnotations();

        public event EventHandler<DataLoadEventArgs> OnDataLoad;
        public event EventHandler<AnnotationEventArgs> OnAnnotationAdd;
        public event EventHandler<AnnotationEventArgs> OnAnnotationRemove;
    }
}
