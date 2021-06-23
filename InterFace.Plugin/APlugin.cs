using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using System;
using System.Collections.Generic;

namespace InterFace.Plugin
{
    public abstract class APlugin
    {
        protected abstract void Init();

        internal void Init(string pluginPath)
        {
            PluginPath = pluginPath;
            Init();
        }

        internal void InitMainTriangle(IMainTriangle triangle)
        {
            Triangle = triangle;
        }

        protected virtual void OnMainTriangleInit()
        { }

        public abstract Control GetView();
        public abstract object GetViewModel();
        public abstract string GetName();
        public abstract IEnumerable<IControl> GetPreferences();

        protected string PluginPath { private set; get; }

        protected IMainTriangle Triangle { private set; get; }

        public void Test<T, U>()
            where T : Control, new()
            where U : new()
        {
            BuildAvaloniaApp<T, U>()
                .StartWithClassicDesktopLifetime(Array.Empty<string>());
        }

        public static AppBuilder BuildAvaloniaApp<T, U>()
            where T : Control, new()
            where U : new()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI()
                .AfterSetup(a => {
                    ((App)a.Instance).OnFrameworkInitializationCompletedCallback = (app) =>
                    {
                        if (app.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                        {
                            desktop.MainWindow = new MainWindow
                            {
                                Content = new T()
                                {
                                    DataContext = new U()
                                }
                            };
                        }
                    };
                });
    }
}
