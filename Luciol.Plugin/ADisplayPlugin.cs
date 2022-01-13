using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Luciol.Plugin.Context;
using System;

namespace Luciol.Plugin
{
    public abstract class ADisplayPlugin : APlugin
    {
        protected ADisplayPlugin() : base()
        {
            _viewModelInstance = GetViewModel();
        }

        /// <summary>
        /// Internal initialization, set context and call Init for child class
        /// </summary>
        /// <param name="context">General context of the application</param>
        internal override void Init(IContext context, Dependency[] dependencies)
        {
            base.Init(context, dependencies);
            _viewModelInstance.Init(this);
        }

        /// <summary>
        /// Create a new instance of the plugin view
        /// </summary>
        public Control CreateViewInstance()
        {
            var view = GetView();
            view.DataContext = _viewModelInstance;
            return view;
        }

        /// <summary>
        /// Move the view on the tab of this plugin
        /// </summary>
        public void Focus()
        {
            OnFocusRequested?.Invoke(this, new());
        }

        internal event EventHandler OnFocusRequested;

        /// <summary>
        /// Returns the view of the plugin window
        /// </summary>
        protected abstract Control GetView();
        /// <summary>
        /// Returns the view model of the plugin window
        /// The goal is to separate the code that display stuffs (in the view) and the code that don't (in the view model)
        /// See MVVM model for more information
        /// </summary>
        protected abstract APluginViewModel GetViewModel();
        private readonly APluginViewModel _viewModelInstance;

        // Data for XAML and starting the view

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
                                Content = new T
                                {
                                    DataContext = new U()
                                }
                            };
                        }
                    };
                });
    }
}
