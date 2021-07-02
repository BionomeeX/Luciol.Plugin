using Avalonia.Controls;

namespace InterFace.Plugin.Preference
{
    public class InputTextPreference : APreference<TextBox, string>
    {
        public override string Value
        {
            get => _component.Text;
            set => _component.Text = value;
        }

        public InputTextPreference(string name, string defaultValue) : base(name, defaultValue)
        { }
    }
}
