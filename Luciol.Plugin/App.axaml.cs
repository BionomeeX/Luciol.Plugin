using Avalonia;
using Avalonia.Markup.Xaml;

namespace Luciol.Plugin
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            OnFrameworkInitializationCompletedCallback.Invoke(this);
            base.OnFrameworkInitializationCompleted();
        }

        public Action<App> OnFrameworkInitializationCompletedCallback { set; private get; }
    }
}
