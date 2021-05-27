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
        {
            return _component;
        }

        private StackPanel _component;

        public CheckBoxPreference(string name)
        {
            _component = new();
            _component.Orientation = Orientation.Horizontal;
            _component.Children.AddRange(new IControl[]
            {
                new Label()
                {
                    Content = name
                },
                new CheckBox()
            });
        }
    }
}
