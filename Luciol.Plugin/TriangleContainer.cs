using Avalonia.Controls;
using System;

namespace Luciol.Plugin
{
    public class TriangleContainer : DockPanel
    {
        internal static Func<TriangleContainer, UserControl> ImplControlConstruction { set; private get; }
        public ATrianglePlugin Plugin { set; internal get; }

        public override sealed void EndInit()
        {
            if (ImplControlConstruction != null)
            {
                Children.Add(ImplControlConstruction(this));
            }
        }

        public void Invalidate()
        {
            InvalidateInternal();
        }

        internal Action InvalidateInternal { set; private get; }
    }
}
