using Luciol.Plugin.Event;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luciol.Plugin.Context
{
    public interface IMainTriangle
    {
        /// <summary>
        /// Add an annotation to the triangle
        /// </summary>
        /// <param name="annotation">Annotation to add</param>
        public void AddAnnotation(IAnnotation annotation);
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
        public bool DoesContainsAnnotation(int posX, int posY, int layer);
        /// <summary>
        /// Check if the given position is in the triangle
        /// </summary>
        /// <param name="posX">X position to check</param>
        /// <param name="posY">Y position to check</param>
        /// <param name="layer">Layer to check</param>
        /// <returns>true if in the triangle, false otherwise</returns>
        public bool IsPositionValid(int posX, int posY, int layer);
        /// <summary>
        /// Get all annotations already placed
        /// </summary>
        public IReadOnlyCollection<IAnnotation> GetAnnotations();

        /// <summary>
        /// Get data about a snip
        /// For a point in the diagonal, a SNP is the vertical line followed by the horizontal line
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="layer"></param>
        /// <exception cref="ArgumentOutOfRangeException">Layer must be between 0 (inclusive) and max layer (exclusive)</exception>
        public Task<float[]> GetSNPDataAsync(int pos, int layer);

        /// <summary>
        /// Get all values on the diagonal
        /// </summary>
        public IReadOnlyCollection<float> GetDiagonal();

        /// <summary>
        /// Called before data are load
        /// This happens when the user move the triangle view
        /// </summary>
        public event EventHandler<EventArgs> OnDataLoading;
        /// <summary>
        /// Called after data are loaded
        /// </summary>
        public event EventHandler<EventArgs> OnDataLoaded;
        /// <summary>
        /// Called right after the resource manager clean removed old data
        /// </summary>
        /// <remarks>This is not called from the main thread</remarks>
        public event EventHandler<EventArgs> OnDataCleaned;
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
