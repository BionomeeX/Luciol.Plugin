using ExtendedAvalonia;
using Luciol.Plugin.Context;
using Luciol.Plugin.Context.Triangle;
using System.Drawing;

namespace Luciol.Plugin.Core
{
    public abstract class ATrianglePlugin : APlugin
    {
        protected ATrianglePlugin() : base()
        { }

        internal override void Init(IContext context, Dependency[] dependencies)
        {
            base.Init(context, dependencies);
            context.GlobalSettings.Triangle.TriangleDiagonalColors.OnChange += (e, sender) =>
            {
                lock (_diagonalColors)
                {
                    _diagonalColors.Clear();
                }
            };
            context.GlobalSettings.Triangle.TriangleMainColors.OnChange += (e, sender) =>
            {
                lock (_mainColors)
                {
                    _mainColors.Clear();
                }
            };
        }

        public abstract ITriangleDataLoader GetDataLoader(string dataPath, uint[] dataDiagonalPositions);

        public abstract int GetValue((int X, int Y) pos, float value);

        public abstract bool HaveDiagonal { get; }

        /// <summary>
        /// Apply a transformation on triangle data
        /// </summary>
        /// <param name="value">Current value of the point</param>
        /// <param name="maxValue">Max value in the triangle</param>
        /// <returns>Color to display</returns>
        public int ValueTransformation(float value, float maxValue, bool onDiagonal)
        {
            var hash = value.GetHashCode();
            Dictionary<int, Color> colors = onDiagonal ? _diagonalColors : _mainColors;
            if (colors.TryGetValue(hash, out Color v))
            {
                return v.ToArgb();
            }
            var color = GradientPicker.GetColorFromPosition((Gradient)(onDiagonal ? Context.GlobalSettings.Triangle.TriangleDiagonalColors.ObjValue : Context.GlobalSettings.Triangle.TriangleMainColors.ObjValue), value / maxValue);
            var sysColor = Color.FromArgb(color.A, color.R, color.G, color.B);
            lock (colors)
            {
                if (!colors.ContainsKey(hash)) // We make sure a second time inside the lock, because of threads
                {
                    colors.Add(hash, sysColor);
                }
            }
            return sysColor.ToArgb();
        }

        public void ClearTriangleColorCache()
        {
            _mainColors.Clear();
            _diagonalColors.Clear();
        }

        private readonly Dictionary<int, Color> _mainColors = new();
        private readonly Dictionary<int, Color> _diagonalColors = new();
    }
}
