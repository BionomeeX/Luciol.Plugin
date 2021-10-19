using Luciol.Plugin.Context;

namespace Luciol.Plugin
{
    public interface IPlugin
    {
        void Init(IContext context, IPlugin[] dependencies);

        public IContext Context { get; }

        public APluginInfo PluginInfo { get; }

        public IPlugin[] Dependencies { get; }
    }
}
