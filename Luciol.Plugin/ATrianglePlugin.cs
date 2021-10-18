using Luciol.Plugin.Context;

namespace Luciol.Plugin
{
    public abstract class ATrianglePlugin : IPlugin
    {
        protected ATrianglePlugin()
        { }

        protected virtual void Init()
        { }

        void IPlugin.Init(IContext context)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Global context, contains various information about the current program
        /// </summary>
        public IContext Context { private set; get; }

        public APluginInfo PluginInfo { internal set; get; }
    }
}
