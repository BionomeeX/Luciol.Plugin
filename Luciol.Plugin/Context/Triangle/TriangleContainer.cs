using Avalonia.Controls;
using Luciol.Plugin.Event;

namespace Luciol.Plugin.Context.Triangle
{
    /// <summary>
    /// View of the triangle
    /// </summary>
    public class TriangleContainer : DockPanel
    {
        internal static Func<TriangleContainer, UserControl> ImplControlConstruction { set; private get; }

        /// <summary>
        /// Event thrown when the triangle is clicked
        /// </summary>
        public event EventHandler<TrianglePositionEventArgs> TriangleOnClick;

        internal void CallTriangleEvent(TrianglePositionEventArgs args)
        {
            TriangleOnClick?.Invoke(this, args);
        }

        public override sealed void EndInit()
        {
            if (ImplControlConstruction != null)
            {
                Children.Add(ImplControlConstruction(this));
            }
        }

        /// <summary>
        /// Invalidate the display of the current view and order a redraw
        /// </summary>
        public void Invalidate()
        {
            InvalidateInternal?.Invoke();
        }

        internal Action InvalidateInternal { set; private get; }
    }
}
