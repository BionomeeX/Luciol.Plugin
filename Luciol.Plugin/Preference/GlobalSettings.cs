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

        public Settings Graph { get; } = new(new[]
        {
            new ColorPreference("mainColor", "Main Graph Color", Color.Black)
        });
    }
}
