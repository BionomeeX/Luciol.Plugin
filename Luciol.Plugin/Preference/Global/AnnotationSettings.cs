using System.Text.Json.Serialization;

namespace Luciol.Plugin.Preference.Global
{
    public class AnnotationSettings : Settings
    {
        public AnnotationSettings() : base(_export)
        { }

        /// <summary>
        /// Set of colors used for Manhattan graphs
        /// </summary>
        [JsonIgnore]
        public CheckBoxPreference AlwaysDisplayAnnotations
        {
            get => (CheckBoxPreference)_export[0];
        }

        private static readonly IPreferenceExport[] _export = new IPreferenceExport[]
        {
            new CheckBoxPreference("alwaysDisplayAnnotations", "Always display annotations", true)
        };
    }
}
