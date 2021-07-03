using Avalonia.Controls;

namespace InterFace.Plugin.Preference
{
    public class InputTextPreference : APreference<TextBox, string>
    {
        public InputTextPreference(string key, string name, string defaultValue) : base(key, name, defaultValue)
        { }

        public override string ComponentValue
        {
            get => _component.Text;
            set => _component.Text = value;
        }
    }
}
