﻿using Luciol.Plugin.Preference;

namespace Luciol.Plugin.Core
{
    public abstract class APluginInfo
    {
        /// <summary>
        /// Name of the plugin
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Name of the author/company who made the plugin
        /// </summary>
        public abstract string Author { get; }
        /// <summary>
        /// Reference to the type of your plugin
        /// Probably typeof(YourPlugin)
        /// </summary>
        protected abstract Type Plugin { get; }
        /// <summary>
        /// Description of what your plugin will do
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Version of your plugin
        /// </summary>
        public abstract string Version { get; }
        /// <summary>
        /// Type of the plugin
        /// </summary>
        public abstract PluginType PluginType { get; }

        public virtual IEnumerable<IPreferenceExport> GetStartingPreferences()
            => Array.Empty<IPreferenceExport>();

        /// <summary>
        /// If your plugin depends of others plugins to work properly
        /// </summary>
        /// <remarks>Your Types must be inheriting APluginInfo!</remarks>
        public virtual Dependency[] Dependencies
        {
            get => Array.Empty<Dependency>();
        }

        internal APlugin Instanciate(IPreferenceExport[] defaultPrefs)
        {
            var plugin = (APlugin)Activator.CreateInstance(Plugin);
            plugin.PluginInfo = this;
            foreach (var p in defaultPrefs)
            {
                plugin.Preferences.FirstOrDefault(x => x.Value.Key == p.Key).Value.ObjValue = p.ObjValue;
            }
            return plugin;
        }

        public override string ToString()
            => $"{Name} by {Author} ({Version})";

        public string Key
        {
            get => $"{Author}/{PluginType}/{Name}";
        }

        public static bool operator ==(APluginInfo a, APluginInfo b)
        {
            if (a is null)
            {
                return b is null;
            }
            if (b is null)
            {
                return false;
            }
            return a.Key == b.Key;
        }

        public static bool operator !=(APluginInfo a, APluginInfo b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            return this == (APluginInfo)obj;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
