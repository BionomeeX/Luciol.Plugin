using System;

namespace Luciol.Plugin.Preference.Global
{
    public class GlobalSettings
    {
        internal GlobalSettings()
        { }

        public Settings General { get; } = new(Array.Empty<IPreferenceExport>());

        public TriangleSettings Triangle { get; } = new();

        public Settings Graph { get; } = new(new IPreferenceExport[]
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
        });
    }
}
