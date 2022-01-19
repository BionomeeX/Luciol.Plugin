using ExtendedAvalonia;
using Luciol.Plugin.Context;
using Luciol.Plugin.Context.Triangle;
using System.Collections.Generic;
using System.Drawing;

namespace Luciol.Plugin
{
    public abstract class ATrianglePlugin : APlugin
    {
        protected ATrianglePlugin() : base()
        { }

        internal override void Init(IContext context, Dependency[] dependencies)
        {
            base.Init(context, dependencies);
            context.GlobalSettings.Triangle.TriangleColors.OnChange += (e, sender) =>
            {
                _colors.Clear();
            };
        }

        public abstract ITriangleDataLoader GetDataLoader(string dataPath, uint[] dataDiagonalPositions);

        public abstract int GetValue((int X, int Y) pos, float value);

        /// <summary>
        /// Apply a transformation on triangle data
        /// </summary>
        /// <param name="value">Current value of the point</param>
        /// <param name="maxValue">Max value in the triangle</param>
        /// <returns>Color to display</returns>
        public int ValueTransformation(float value, float maxValue)
        {
            var hash = value.GetHashCode();
            if (_colors.TryGetValue(hash, out Color v))
            {
                return v.ToArgb();
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
            return sysColor.ToArgb();
        }
        private readonly Dictionary<int, Color> _colors = new();
    }
}
