using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Luciol.Plugin.Preference.Global
{
    public class Settings
    {
        public Settings(IEnumerable<IPreferenceExport> settings)
        {
            Preferences = new ReadOnlyDictionary<string, IPreferenceExport>(
                settings.Select(x => new KeyValuePair<string, IPreferenceExport>(x.Key, x)).ToDictionary(x => x.Key, x => x.Value)
            );
        }

        [EditorBrowsable(EditorBrowsableState.Never)] // Attribut used for JSON serialization
        public ReadOnlyDictionary<string, IPreferenceExport> Preferences { private set; get; }
    }
}
