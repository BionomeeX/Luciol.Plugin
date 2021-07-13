using Avalonia.Controls;

namespace Luciol.Plugin.Preference
{
    public class CheckBoxPreference : APreference<CheckBox, bool>
    {
        public CheckBoxPreference(string key, string name, bool defaultValue) : base(key, name, defaultValue)
        { }

        protected override bool ComponentValue
        {
            get => _component.IsChecked == true;
            set => _component.IsChecked = value;
        }
    }
}
