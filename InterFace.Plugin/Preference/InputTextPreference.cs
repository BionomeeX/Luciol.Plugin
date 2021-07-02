using Avalonia.Controls;
using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin.Preference
{
    public class InputTextPreference : APreference<TextBox, string>
    {
        public event EventHandler<PreferenceEventArgs<string>> OnChange;

        public IControl GetComponent()
            => _component;

        private readonly string _name;

        public override string Name => _name;

        public override string Value
        {
            get => _component.Text;
            set => _component.Text = value;
        }

        public InputTextPreference(string name, string defaultValue = "") : base(name, defaultValue)
        { }
    }
}
