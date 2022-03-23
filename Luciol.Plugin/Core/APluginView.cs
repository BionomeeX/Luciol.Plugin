using Avalonia.Controls;
using Avalonia.ReactiveUI;

namespace Luciol.Plugin.Core
{
    public class APluginView<T> : ReactiveUserControl<T>, IPluginView
        where T : APluginViewModel
    {
        object IPluginView.ViewModel { get => ViewModel; set => ViewModel = (T)value; }
        ADisplayPlugin IPluginView.Plugin { set => _plugin = value; }

        public virtual void Init(ADisplayPlugin plugin)
        { }

        Control IPluginView.Copy()
        {
            var newContent = (IPluginView)Activator.CreateInstance(GetType());
            newContent.ViewModel = ViewModel;
            newContent.Plugin = _plugin;
            newContent.Init(_plugin);
            return (Control)newContent;
        }

        private ADisplayPlugin _plugin;
    }
}
