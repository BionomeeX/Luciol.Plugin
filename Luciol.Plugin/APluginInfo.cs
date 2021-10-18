using System;

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

        public static bool operator ==(APluginInfo a, APluginInfo b)
        {
            if (a is null)
            {
                return b is null;
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
