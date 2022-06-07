using ExtendedAvalonia;
using ExtendedAvalonia.Slider;
using System.Text.Json.Serialization;

namespace Luciol.Plugin.Preference.Global
{
    public sealed class TriangleSettings : Settings
    {
        internal TriangleSettings() : base(_export)
        { }

        /// <summary>
        /// Sensitivity used when doing drag & drop operation with the mouse
        /// </summary>
        [JsonIgnore]
        public NumberInputTextPreference<float> DragAndDropSensitivity
        {
            get => (NumberInputTextPreference<float>)_export[0];
        }

        /// <summary>
        /// Gradient used for managing the main colors of the triangle
        /// </summary>
        [JsonIgnore]
        public GradientPreference TriangleMainColors
        {
            get => (GradientPreference)_export[1];
        }

        /// <summary>
        /// Gradient used for managing the diagonal colors of the triangle
        /// </summary>
        [JsonIgnore]
        public GradientPreference TriangleDiagonalColors
        {
            get => (GradientPreference)_export[2];
        }

        [JsonIgnore]
        public NumberInputTextPreference<int> MinimalPixelSize
        {
            get => (NumberInputTextPreference<int>) _export[3];
        }

        private static readonly IPreferenceExport[] _export = new IPreferenceExport[]
        {
            new NumberInputTextPreference<float>("dragAndDropSensitivity", "Drag and Drop Sensitivity", 1f),
            new GradientPreference("triangleMainColors", "EpistaticMap Main Colors",
                new Gradient(
                    new PositionColor[]
                    {
                        new() { Position = 0.4, Color = Color.Black },
                        new() { Position = 0.75, Color = Color.FromRgb(107, 3, 79) },
                        new() { Position = 1.0, Color = Color.FromRgb(255, 233, 0) }
                    }
                )),
            new GradientPreference("triangleDiagonalColors", "EpistaticMap Diagonal Colors",
                new Gradient(
                    new PositionColor[]
                    {
                        new() { Position = 0.0, Color = Color.Black },
                        new() { Position = 1.0, Color = Color.Blue }
                    }
                )),
            new NumberInputTextPreference<int>("minPixelSize", "Minimal pixel size", 3)
        };
    }
}
