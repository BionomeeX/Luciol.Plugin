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

        private static readonly IPreferenceExport[] _export = new IPreferenceExport[]
        {
            new NumberInputTextPreference<float>("dragAndDropSensitivity", "Drag and Drop Sensitivity", 1f),
            new GradientPreference("triangleMainColors", "Triangle Main Colors",
                new Gradient()
                {
                    PositionColors = new PositionColor[]
                    {
                        new() { Position = 0.0, Color = Color.Black },
                        new() { Position = 1.0, Color = Color.Blue }
                    }
                }),
            new GradientPreference("triangleDiagonalColors", "Triangle Diagonal Colors",
                new Gradient()
                {
                    PositionColors = new PositionColor[]
                    {
                        new() { Position = 0.0, Color = Color.Black },
                        new() { Position = 1.0, Color = Color.Blue }
                    }
                })
        };
    }
}
