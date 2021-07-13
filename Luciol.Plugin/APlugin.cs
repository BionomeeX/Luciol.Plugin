using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Luciol.Plugin.Preference;
using System;
using System.Collections.Generic;

namespace Luciol.Plugin
{
    public abstract class APlugin
    {
        /// <summary>
        /// Plugins need to do their initialization here instead of the ctor
        /// The reason is that Context is garenteed to be not null in the Init function
        /// </summary>
        protected abstract void Init();

        /// <summary>
        /// Internal initialization, set context and call Init for child class
        /// </summary>
        /// <param name="context">General context of the application</param>
        internal void Init(IContext context)
        {
            Context = context;
            Init();
        }

        /// <summary>
        /// Returns the view of the plugin window
        /// </summary>
        public abstract Control GetView();
        /// <summary>
        /// Returns the view model of the plugin window
        /// The goal is to separate the code that display stuffs (in the view) and the code that don't (in the view model)
        /// See MVVM model for more information
        /// </summary>
        public abstract object GetViewModel();
        /// <summary>
        /// Get the preference (settings)
        /// You can create your preferences with the child classes of APreference (APreference already implement IPreferenceExport)
        /// </summary>
        public abstract IEnumerable<IPreferenceExport> GetPreferences();

        /// <summary>
        /// Global context, contains various information about the current program
        /// </summary>
        protected IContext Context { private set; get; }

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
