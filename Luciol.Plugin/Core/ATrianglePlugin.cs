using ExtendedAvalonia;
using ExtendedAvalonia.Slider;
using Luciol.Plugin.Context;
using Luciol.Plugin.Context.Triangle;
using Luciol.Plugin.Preference;
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
            MainGradientPreference =
                new GradientPreference("triangleMainColors", "Triangle Main Colors",
                new Gradient(
                    new PositionColor[]
                    {
                        new() { Position = 0.4, Color = Preference.Color.Black },
                        new() { Position = 0.75, Color = Preference.Color.FromRgb(107, 3, 79) },
                        new() { Position = 1.0, Color = Preference.Color.FromRgb(255, 233, 0) }
                    }
                ));
            DiagonalGradientPreference =
                new GradientPreference("triangleDiagonalColors", "Triangle Diagonal Colors",
                new Gradient(
                    new PositionColor[]
                    {
                        new() { Position = 0.0, Color = Preference.Color.Black },
                        new() { Position = 1.0, Color = Preference.Color.Blue }
                    }
                ));
            MainGradientPreference.OnChange += (e, sender) =>
            {
                lock (_diagonalColors)
                {
                    _diagonalColors.Clear();
                }
            };
            DiagonalGradientPreference.OnChange += (e, sender) =>
            {
                lock (_mainColors)
                {
                    _mainColors.Clear();
                }
            };
        }

        protected override IEnumerable<IPreferenceExport> GetPreferences()
        {
            return new IPreferenceExport[] { MainGradientPreference, DiagonalGradientPreference };
        }

        public abstract ITriangleDataLoader GetDataLoader(string dataPath, long[] dataDiagonalPositions);

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
            Dictionary<int, System.Drawing.Color> colors = onDiagonal ? _diagonalColors : _mainColors;
            if (colors.TryGetValue(hash, out System.Drawing.Color v))
            {
                return v.ToArgb();
            }
            var color = GradientPicker.GetColorFromPosition((Gradient)(onDiagonal ? DiagonalGradientPreference.ObjValue : MainGradientPreference.ObjValue), value / maxValue);
            var sysColor = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
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

        private readonly Dictionary<int, System.Drawing.Color> _mainColors = new();
        private readonly Dictionary<int, System.Drawing.Color> _diagonalColors = new();

        private GradientPreference MainGradientPreference, DiagonalGradientPreference;
    }
}
