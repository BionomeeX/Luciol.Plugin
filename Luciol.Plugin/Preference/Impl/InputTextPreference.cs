using Avalonia.Controls;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Input text preference, store a string
    /// </summary>
    public class InputTextPreference : APreference<TextBox, string>
    {
        public InputTextPreference(string key, string name, string defaultValue) : base(key, name, defaultValue)
        { }

        protected override string ComponentValue
        {
            get => _component.Text;
            set => _component.Text = value;
        }
    }
}
