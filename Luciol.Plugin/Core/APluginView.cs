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

        Window IPluginView.Copy()
        {
            var newContent = (IPluginView)Activator.CreateInstance(GetType());
            newContent.ViewModel = ViewModel;
            var newWindow = new Window
            {
                Content = newContent
            };
            newContent.Plugin = _plugin;
            newContent.Init(_plugin);
            return newWindow;
        }

        private ADisplayPlugin _plugin;
    }
}
