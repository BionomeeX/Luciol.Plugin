using Luciol.Plugin.Context;

namespace Luciol.Plugin
{
    public abstract class ATrianglePlugin : IPlugin
    {
        protected ATrianglePlugin()
        { }

        protected virtual void Init()
        { }

        void IPlugin.Init(IContext context, IPlugin[] dependencies)
        {
            Context = context;
            Dependencies = dependencies;
        }

        /// <summary>
        /// Global context, contains various information about the current program
        /// </summary>
        public IContext Context { private set; get; }

        public APluginInfo PluginInfo { internal set; get; }

        public IPlugin[] Dependencies { private set; get; }
    }
}
