using Avalonia.Controls;
using System;

namespace InterFace.Plugin
{
    public class TriangleContainer : DockPanel
    {
        internal static Func<UserControl> ImplControlConstruction { set; private get; }

        public override void EndInit()
        {
            if (ImplControlConstruction != null)
            {
                Children.Add(ImplControlConstruction());
            }
        }
    }
}
