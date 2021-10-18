using Luciol.Plugin.Context;

namespace Luciol.Plugin
{
    public interface IPlugin
    {
        void Init(IContext context);

        public IContext Context { get; }

        public PluginInfo PluginInfo { get; }
    }
}
