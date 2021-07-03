using Avalonia.Controls;

namespace InterFace.Plugin.Preference
{
    public class CheckBoxPreference : APreference<CheckBox, bool>
    {
        public CheckBoxPreference(string key, string name, bool defaultValue) : base(key, name, defaultValue)
        { }

        public override bool ComponentValue
        {
            get => _component.IsChecked == true;
            set => _component.IsChecked = value;
        }
    }
}
