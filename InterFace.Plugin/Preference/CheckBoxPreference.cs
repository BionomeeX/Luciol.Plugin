using Avalonia.Controls;
using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin.Preference
{
    public class CheckBoxPreference : APreference<CheckBox, bool>
    {
        public event EventHandler<PreferenceEventArgs<bool>> OnChange;

        public IControl GetComponent()
            => _component;

        private readonly string _name;

        public override string Name => _name;

        public override bool Value
        {
            get => _component.IsChecked.Value;
            set => _component.IsChecked = value;
        }

        public CheckBoxPreference(string name, bool defaultValue = false) : base(name, defaultValue)
        { }
    }
}
