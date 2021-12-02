using ExtendedAvalonia;
using Luciol.Plugin.Context;
using Luciol.Plugin.Context.Annotation;
using Luciol.Plugin.Preference.Global;
using System.Collections.Generic;

namespace Luciol.Plugin
{
    public abstract class ATrianglePlugin : APlugin
    {
        protected ATrianglePlugin() : base()
        { }

        internal override void Init(IContext context, APlugin[] dependencies)
        {
            base.Init(context, dependencies);
            context.GlobalSettings.Triangle.TriangleColors.OnChange += (e, sender) =>
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
            var color = GradientPicker.GetColorFromPosition((Gradient)Context.GlobalSettings.Triangle.TriangleColors.ObjValue, value / maxValue);
            var sysColor = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
            lock (_colors)
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
