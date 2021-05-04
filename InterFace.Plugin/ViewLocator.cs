using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ReactiveUI;
using System;

namespace InterFace.Plugin
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public IControl Build(object _)
        {
            return (Control)Activator.CreateInstance(Type.GetType("MainWindowView"));
        }

        public bool Match(object data)
        {
            return data is ReactiveObject;
        }
    }
}
