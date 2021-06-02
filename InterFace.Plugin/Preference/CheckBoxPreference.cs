using Avalonia.Controls;
using Avalonia.Layout;
using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin.Preference
{
    public class CheckBoxPreference : IPreference<bool>
    {
        public event EventHandler<PreferenceEventArgs<bool>> OnChange;

        public IControl GetComponent()
            => _component;

        private readonly StackPanel _component;
        private readonly CheckBox _checkBox;
        private readonly string _name;

        public string Name => _name;

        public bool Value
        {
            get => _checkBox.IsChecked.Value;
            set => _checkBox.IsChecked = value;
        }

        public CheckBoxPreference(string name)
        {
            _checkBox = new CheckBox();
            _component = new();
            _component.Orientation = Orientation.Horizontal;
            _component.Children.AddRange(new IControl[]
            {
                new Label()
                {
                    Content = name
                },
                _checkBox
            });
            _name = name;
        }
    }
}
