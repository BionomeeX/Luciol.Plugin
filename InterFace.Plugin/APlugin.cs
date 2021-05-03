namespace InterFace.Plugin
{
    public abstract class APlugin
    {
        protected abstract void Init();

        internal void Init(IMainTriangle triangle, string pluginPath)
        {
            PluginPath = pluginPath;
            Triangle = triangle;
            Init();
        }

        protected string PluginPath { private set; get; }

        protected IMainTriangle Triangle { private set; get; }
    }
}
