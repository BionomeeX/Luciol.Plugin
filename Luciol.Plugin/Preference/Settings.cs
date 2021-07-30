using Luciol.Plugin.Preference;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Luciol.Plugin.Models.Preference
{
    public class Settings
    {
        public Settings(IEnumerable<IPreferenceExport> settings)
        {
            Preferences = new ReadOnlyDictionary<string, IPreferenceExport>(
                settings.Select(x => new KeyValuePair<string, IPreferenceExport>(x.Key, x)).ToDictionary(x => x.Key, x => x.Value)
            );
        }

        public ReadOnlyDictionary<string, IPreferenceExport> Preferences { private set; get; }
    }
}
