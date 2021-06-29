using Avalonia.Controls;
using Avalonia.Layout;
using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin.Preference
{
    public abstract class APreference<Component, Type> : IPreferenceExport
        where Component : IControl, new()
    {
        public event EventHandler<PreferenceEventArgs<Type>> OnChange;

        public abstract Type Value { set; get; }

        public abstract string Name { get; }

        protected APreference(string name)
        {
            _component = new();

            _parent = new();
            _parent.Orientation = Orientation.Horizontal;
            _parent.Children.AddRange(new IControl[]
            {
                new Label()
                {
                    Content = name
                },
                _component
            });
        }

        private readonly StackPanel _parent;
        protected readonly Component _component;

        public IControl GetComponent()
            => _component;
    }
}
