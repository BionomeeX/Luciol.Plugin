using ExtendedAvalonia;
using Luciol.Plugin.Context;
using Luciol.Plugin.Context.Triangle;
using Luciol.Plugin.Preference.Global;
using System.Collections.Generic;
using System.Drawing;

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

        public abstract ITriangleDataLoader GetDataLoader(string dataPath, uint[] dataDiagonalPositions);

        public abstract Color GetValue((int X, int Y) pos, float value);

        /// <summary>
        /// Apply a transformation on triangle data
        /// </summary>
        /// <param name="value">Current value of the point</param>
        /// <param name="maxValue">Max value in the triangle</param>
        /// <returns>Color to display</returns>
        public Color ValueTransformation(float value, float maxValue, GlobalSettings settings)
        {
            var hash = value.GetHashCode();
            if (_colors.TryGetValue(hash, out Color v))
            {
                return v;
            }
            var color = GradientPicker.GetColorFromPosition((Gradient)Context.GlobalSettings.Triangle.TriangleColors.ObjValue, value / maxValue);
            var sysColor = Color.FromArgb(color.A, color.R, color.G, color.B);
            lock (_colors)
            {
                if (!_colors.ContainsKey(hash)) // We make sure a second time inside the lock, because of threads
                {
                    _colors.Add(hash, sysColor);
                }
            }
            return sysColor;
        }
        private readonly Dictionary<int, Color> _colors = new();
    }
}
