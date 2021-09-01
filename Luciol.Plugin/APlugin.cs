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
    public abstract class APlugin
    {
        protected APlugin()
        {
             Preferences = new ReadOnlyDictionary<string, IPreferenceExport>(
                GetPreferences().Select(x => new KeyValuePair<string, IPreferenceExport>(x.Key, x)).ToDictionary(x => x.Key, x => x.Value)
             );
            _viewModelInstance = GetViewModel();
        }

        /// <summary>
        /// Plugins need to do their initialization here instead of the ctor
        /// The reason is that Context is garenteed to be not null in the Init function
        /// </summary>
        protected virtual void Init()
        { }

        /// <summary>
        /// Internal initialization, set context and call Init for child class
        /// </summary>
        /// <param name="context">General context of the application</param>
        internal void Init(IContext context)
        {
            Context = context;
            _viewModelInstance.Init(this);
            Init();
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

        internal object CustomDataInit { set; private get; }
        private ICustomData _customData;
        public ICustomData CustomData
        {
            set
            {
                _customData = value;
                _customData.Init(CustomDataInit);
            }
            get
            {
                return _customData;
            }
        }

        public ReadOnlyDictionary<string, IPreferenceExport> Preferences { private set; get; }

        /// <summary>
        /// Global context, contains various information about the current program
        /// </summary>
        public IContext Context { private set; get; }

        public PluginInfo PluginInfo { internal set; get; }

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
