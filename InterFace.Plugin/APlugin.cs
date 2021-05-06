﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using System;

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

        public abstract Window GetView();
        public abstract object GetViewModel();
        public abstract string GetName();

        protected string PluginPath { private set; get; }

        protected IMainTriangle Triangle { private set; get; }

        public void Test<T, U>()
            where T : Window, new()
            where U : new()
        {
            BuildAvaloniaApp<T, U>()
                .StartWithClassicDesktopLifetime(Array.Empty<string>());
        }

        public static AppBuilder BuildAvaloniaApp<T, U>()
            where T : Window, new()
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
                            desktop.MainWindow = new T
                            {
                                DataContext = new U()
                            };
                        }
                    };
                });
    }
}
