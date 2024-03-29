﻿using Luciol.Plugin.Context;
using Luciol.Plugin.Preference;
using Luciol.Plugin.SaveLoad;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace Luciol.Plugin.Core
{
    public abstract class APlugin
    {
        protected APlugin()
        { }

        internal virtual void Init(IContext context, Dependency[] dependencies, string resourcesPath, ILogger logger)
        {
            Context = context;
            Dependencies = dependencies;
            ResourcesPath = resourcesPath;
            _logger = logger;
            Init();
        }

        public string ResourcesPath { private set; get; }

        /// <summary>
        /// Plugins need to do their initialization here instead of the ctor
        /// The reason is that Context is garenteed to be not null in the Init function
        /// </summary>
        protected virtual void Init()
        { }

        /// <summary>
        /// Global context, contains various information about the current program
        /// </summary>
        public IContext Context { protected set; get; }

        /// <summary>
        /// Metadata about the plugin
        /// </summary>
        public APluginInfo PluginInfo { internal set; get; }

        public Dependency[] Dependencies { protected set; get; }

        public T? GetDependency<T>()
            where T : APlugin
            => (T?)Dependencies.FirstOrDefault(x => x.Plugin is T)?.Plugin;

        /// <summary>
        /// Plugin preferences
        /// </summary>
        private ReadOnlyDictionary<string, IPreferenceExport> _preferences;
        public ReadOnlyDictionary<string, IPreferenceExport> Preferences
        {
            protected set => _preferences = value;
            get
            {
                if (_preferences == null)
                {
                    _preferences = new ReadOnlyDictionary<string, IPreferenceExport>(
                        GetPreferences().Select(x => new KeyValuePair<string, IPreferenceExport>(x.Key, x)).ToDictionary(x => x.Key, x => x.Value)
                    );
                }
                return _preferences;
            }
        }

        /// <summary>
        /// A plugin can save whatever it wants using this
        /// </summary>
        public ICustomData CustomData
        {
            set
            {
                _customData = value;
                _customData.Init(CustomDataInit);
            }
            get
            {
                return _customData;
            }
        }
        internal object CustomDataInit { set; private get; }
        private ICustomData _customData;

        /// <summary>
        /// Get the preference (settings)
        /// You can create your preferences with the child classes of APreference (APreference already implement IPreferenceExport)
        /// </summary>
        protected virtual IEnumerable<IPreferenceExport> GetPreferences()
            => Array.Empty<IPreferenceExport>();

        protected virtual void Log(string message, LogLevel level)
        {
            _logger.Log(level, message);
        }
        private ILogger _logger;
    }
}
