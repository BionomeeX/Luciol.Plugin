using Avalonia.Controls;
using ExtendedAvalonia;
using ExtendedAvalonia.Slider;
using Luciol.Plugin.Models.Preference;
using Luciol.Plugin.Preference;
using System;
using System.Collections.Generic;

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

        public void Init(GlobalSettings settings)
        {
            ((GradientPreference)settings.Triangle.Preferences["triangleColors"]).OnChange += (e, sender) =>
            {
                _colors.Clear();
            };
        }

        /// <summary>
        /// Apply a transformation on triangle data
        /// </summary>
        /// <param name="value">Current value of the point</param>
        /// <param name="maxValue">Max value in the triangle</param>
        /// <returns>Color to display</returns>
        public virtual System.Drawing.Color ValueTransformation(float value, float maxValue, GlobalSettings settings)
        {
            var hash = value.GetHashCode();
            if (_colors.TryGetValue(hash, out System.Drawing.Color v))
            {
                return v;
            }
            var color = GradientPicker.GetColorFromPosition((PositionColor[])settings.Triangle.Preferences["triangleColors"].Value, value / maxValue);
            var sysColor = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
            lock(_colors)
            {
                if (!_colors.ContainsKey(hash)) // We make sure a second time inside the lock, because of threads
                {
                    _colors.Add(hash, sysColor);
                }
            }
            return sysColor;
        }

        private readonly Dictionary<int, System.Drawing.Color> _colors = new();
    }
}
