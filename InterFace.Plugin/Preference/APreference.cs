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

        public abstract Type ComponentValue { set; get; }
        protected Type _value { private set; get; }
        private readonly Type _defaultValue;

        public string Name { init; get; }

        protected APreference(string name, Type defaultValue)
        {
            Name = name;
            _defaultValue = defaultValue;
            _value = defaultValue;
        }

        protected Component _component;

        public IControl GetComponent()
        {
            _component = new();
            ComponentValue = _value;
            _component.PropertyChanged += (sender, e) =>
            {
                _value = ComponentValue; // TODO: Doesn't work for NumberInputText
                OnChange?.Invoke(this, new PreferenceEventArgs<Type>(_value));
            };

            var parent = new StackPanel();
            parent = new();
            parent.Orientation = Orientation.Horizontal;
            parent.Children.AddRange(new IControl[]
            {
                new Label()
                {
                    Content = Name
                },
                _component
            });
            return parent;
        }
    }
}
