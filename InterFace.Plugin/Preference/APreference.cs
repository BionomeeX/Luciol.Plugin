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

        public string Key { init; get; }
        public string Name { init; get; }

        public object Value
        {
            set
            {
                _value = (Type)Convert.ChangeType(value, typeof(Type));
            }
            get
            {
                return _value;
            }
        }

        protected APreference(string key, string name, Type defaultValue)
            => (Key, Name, _defaultValue, _value) = (key, name, defaultValue, _defaultValue);

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
