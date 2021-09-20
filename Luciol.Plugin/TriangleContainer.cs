using Avalonia.Controls;
using ExtendedAvalonia;
using ExtendedAvalonia.Slider;
using Luciol.Plugin.Models.Preference;
using System;

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
        /// </summary>
        /// <param name="value">Current value of the point</param>
        /// <param name="maxValue">Max value in the triangle</param>
        /// <returns>Color to display</returns>
        public virtual System.Drawing.Color ValueTransformation(float value, float maxValue, GlobalSettings settings)
        {
            var color = GradientPicker.GetColorFromPosition((PositionColor[])settings.Triangle.Preferences["triangleColors"].Value, value / maxValue);
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
