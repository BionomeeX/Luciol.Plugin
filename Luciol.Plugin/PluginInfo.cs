using System;
using System.Reflection;

namespace Luciol.Plugin
{
    public class PluginInfo
    {
        public PluginInfo(Assembly assembly, Type plugin)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), "Assembly cannot be null");
            }
            var version = assembly.GetName().Version;
            Version = version == null ? "Dev" : $"{version.Major}.{version.Minor}.{version.Revision}";
            _name = assembly.GetName().Name;
            _author = "Unknown";
            _plugin = plugin;
        }

        private readonly string _name;
        private readonly string _author;
        public string Version { init; get; }
        private readonly Type _plugin;

        internal APlugin Instanciate()
        {
            var plugin = (APlugin)Activator.CreateInstance(_plugin);
            plugin.PluginInfo = this;
            return plugin;
        }

        public override string ToString()
        {
            return $"{_name} ({Version})";
        }

        public string Key
        {
            get
            {
                return _author + "_" + _name;
            }
        }
    }
}
