using Luciol.Plugin.AssemblyAttribute;
using System;
using System.Reflection;

namespace Luciol.Plugin
{
    public class PluginInfo
    {
        public PluginInfo(Assembly assembly, Type plugin, PluginType pluginType)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), "Assembly cannot be null");
            }
            PluginType = pluginType;
            var version = assembly.GetName().Version;
            _name = assembly.GetName().Name;
            _author = assembly.GetCustomAttribute<AssemblyAuthorAttribute>()?.Author ?? "Unkown";
            Version = version == null ? "Dev" : $"{version.Major}.{version.Minor}.{version.Revision}";
            Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty;
            _plugin = plugin;
        }

        private readonly string _name;
        private readonly string _author;
        public string Description { private init; get; }
        public string Version { private init; get; }
        public PluginType PluginType { private init; get; }
        private readonly Type _plugin;

        internal ADisplayPlugin Instanciate()
        {
            var plugin = (ADisplayPlugin)Activator.CreateInstance(_plugin);
            plugin.PluginInfo = this;
            return plugin;
        }

        public override string ToString()
        {
            return $"{_name} by {_author} ({Version})";
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
