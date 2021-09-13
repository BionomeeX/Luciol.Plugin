using Luciol.Plugin.Preference;

namespace Luciol.Plugin.Models.Preference
{
    public class GlobalSettings
    {
        internal GlobalSettings()
        { }

        public Settings General { get; } = new(new IPreferenceExport[]
        {

        });

        public Settings Triangle { get; } = new(new[]
        {
            new NumberInputTextPreference<float>("dragAndDropSensitivity", "Drag and Drop Sensitivity", 1f)
        });

        public Settings Graph { get; } = new(new IPreferenceExport[]
        {
            new ColorPreference("mainColor", "Main Graph Color", Color.Black),
            new ColorPalettePreference("manhattanColors", "Colors used for Manhattan graph",
                new[] {
                    Color.FromRgb(27, 158, 119),
                    Color.FromRgb(217, 95, 2),
                    Color.FromRgb(117, 112, 179),
                    Color.FromRgb(231, 41, 138),
                    Color.FromRgb(230, 171, 2),
                    Color.FromRgb(166, 118, 29)
                })
        });
    }
}
