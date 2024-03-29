﻿using System.Text.Json.Serialization;

namespace Luciol.Plugin.Preference.Global
{
    public sealed class GraphSettings : Settings
    {
        internal GraphSettings() : base(_export)
        { }

        /// <summary>
        /// Main color used for linear graphs
        /// </summary>
        [JsonIgnore]
        public ColorPreference MainColor
        {
            get => (ColorPreference)_export[0];
        }

        /// <summary>
        /// Set of colors used for Manhattan graphs
        /// </summary>
        [JsonIgnore]
        public ColorPalettePreference ManhattanColors
        {
            get => (ColorPalettePreference)_export[1];
        }

        [JsonIgnore]
        public NumberInputTextPreference<int> MaxSelection => (NumberInputTextPreference<int>)_export[2];

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
                }),
            new NumberInputTextPreference<int>("maxSelection", "Max Nb of Points Selectable", 100)
        };
    }
}
