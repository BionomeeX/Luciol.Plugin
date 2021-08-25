using Luciol.Plugin.AssemblyAttribute;
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
        private readonly Type _plugin;

        internal APlugin Instanciate()
        {
            var plugin = (APlugin)Activator.CreateInstance(_plugin);
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
