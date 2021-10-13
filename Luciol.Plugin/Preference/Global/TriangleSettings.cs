using ExtendedAvalonia;
using ExtendedAvalonia.Slider;
using System.Text.Json.Serialization;

namespace Luciol.Plugin.Preference.Global
{
    public sealed class TriangleSettings : Settings
    {
        internal TriangleSettings() : base(_export)
        { }

        [JsonIgnore]
        public NumberInputTextPreference<float> DragAndDropSensitivity
        {
            get => (NumberInputTextPreference<float>)_export[0];
        }

        [JsonIgnore]
        public GradientPreference TriangleColors
        {
            get => (GradientPreference)_export[1];
        }

        private static readonly IPreferenceExport[] _export = new IPreferenceExport[]
        {
            new NumberInputTextPreference<float>("dragAndDropSensitivity", "Drag and Drop Sensitivity", 1f),
            new GradientPreference("triangleColors", "Triangle Colors",
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
