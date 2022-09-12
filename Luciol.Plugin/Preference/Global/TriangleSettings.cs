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

        [JsonIgnore]
        public NumberInputTextPreference<int> MinimalPixelSize
        {
            get => (NumberInputTextPreference<int>) _export[1];
        }

        private static readonly IPreferenceExport[] _export = new IPreferenceExport[]
        {
            new NumberInputTextPreference<float>("dragAndDropSensitivity", "Drag and Drop Sensitivity", 1f),
            new NumberInputTextPreference<int>("minPixelSize", "Minimal pixel size", 3)
        };
    }
}
