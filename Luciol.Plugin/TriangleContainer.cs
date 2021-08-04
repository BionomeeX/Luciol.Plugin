using Avalonia.Controls;
using System;
using System.Drawing;

namespace Luciol.Plugin
{
    public class TriangleContainer : DockPanel
    {
        internal static Func<TriangleContainer, UserControl> ImplControlConstruction { set; private get; }

        public override sealed void EndInit()
        {
            if (ImplControlConstruction != null)
            {
                Children.Add(ImplControlConstruction(this));
            }
        }

        /// <summary>
        /// Apply a transformation on triangle data
        /// This is useful if you need to modify them because they are displayed
        /// By default we just display a scale of blue depending of its value
        /// </summary>
        /// <param name="value">Current value of the point</param>
        /// <param name="maxValue">Max value in the triangle</param>
        /// <returns>Color to display</returns>
        public virtual Color ValueTransformation(float value, float maxValue)
            => Color.FromArgb(0, 0, (int)(Math.Abs(value) * 255 / maxValue));
    }
}
