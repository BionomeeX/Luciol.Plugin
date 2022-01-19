using Avalonia.ReactiveUI;

namespace Luciol.Plugin
{
    public class APluginView<T> : ReactiveUserControl<T>, IPluginView
        where T : APluginViewModel
    {
        public virtual void Init(ADisplayPlugin plugin)
        { }
    }
}
