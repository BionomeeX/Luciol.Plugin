using Avalonia.Controls;
using Luciol.Plugin.Event;
using System;

namespace Luciol.Plugin.Context.Triangle
{
    public class TriangleContainer : DockPanel
    {
        internal static Func<TriangleContainer, UserControl> ImplControlConstruction { set; private get; }
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

        public void Invalidate()
        {
            InvalidateInternal?.Invoke();
        }

        internal Action InvalidateInternal { set; private get; }
    }
}
