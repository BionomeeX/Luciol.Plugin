using System.Text.Json.Serialization;

namespace Luciol.Plugin.Preference.Global
{
    public sealed class GraphSettings : Settings
    {
        internal GraphSettings() : base(_export)
        { }

        [JsonIgnore]
        public ColorPreference MainColor
        {
            get => (ColorPreference)_export[0];
        }

        [JsonIgnore]
        public ColorPalettePreference ManhattanColors
        {
            get => (ColorPalettePreference)_export[1];
        }

        private static readonly IPreferenceExport[] _export = new IPreferenceExport[]
        {
            new ColorPreference("mainColor", "Main Graph Color", Color.Black),
            new ColorPalettePreference("manhattanColors", "Colors used for Manhattan graph",
                new ColorPalette()
                {
                    Colors =
                    new[] {
                        Color.FromRgb(27, 158, 119),
                        Color.FromRgb(217, 95, 2),
                        Color.FromRgb(117, 112, 179),
                        Color.FromRgb(231, 41, 138),
                        Color.FromRgb(230, 171, 2),
                        Color.FromRgb(166, 118, 29)
                    }
                })
        };
    }
}
