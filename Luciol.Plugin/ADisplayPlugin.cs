using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Luciol.Plugin.Context;
using Luciol.Plugin.SaveLoad;
using Luciol.Plugin.Preference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Luciol.Plugin
{
    public abstract class ADisplayPlugin : APlugin
    {
        protected ADisplayPlugin()
        {
             Preferences = new ReadOnlyDictionary<string, IPreferenceExport>(
                GetPreferences().Select(x => new KeyValuePair<string, IPreferenceExport>(x.Key, x)).ToDictionary(x => x.Key, x => x.Value)
             );
            _viewModelInstance = GetViewModel();
        }

        /// <summary>
        /// Internal initialization, set context and call Init for child class
        /// </summary>
        /// <param name="context">General context of the application</param>
        internal override void Init(IContext context, APlugin[] dependencies)
        {
            _viewModelInstance.Init(this);
            base.Init(context, dependencies);
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
        /// <summary>
        /// Get the preference (settings)
        /// You can create your preferences with the child classes of APreference (APreference already implement IPreferenceExport)
        /// </summary>
        protected abstract IEnumerable<IPreferenceExport> GetPreferences();

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
