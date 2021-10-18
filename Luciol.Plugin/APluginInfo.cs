using Luciol.Plugin.AssemblyAttribute;
using System;
using System.Reflection;

namespace Luciol.Plugin
{
    public abstract class APluginInfo
    {
        protected abstract string Name { get; }
        protected abstract string Author { get; }
        protected abstract Type Plugin { get; }
        public abstract string Description { get; }
        public abstract string Version { get; }
        public abstract PluginType PluginType { get; }

        internal ADisplayPlugin Instanciate()
        {
            var plugin = (ADisplayPlugin)Activator.CreateInstance(Plugin);
            plugin.PluginInfo = this;
            return plugin;
        }

        public override string ToString()
        {
            return $"{Name} by {Author} ({Version})";
        }

        public string Key
        {
            get
            {
                return $"{PluginType}_{Author}_{Name}";
            }
        }
    }
}
