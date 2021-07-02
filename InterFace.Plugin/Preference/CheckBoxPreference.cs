using Avalonia.Controls;

namespace InterFace.Plugin.Preference
{
    public class CheckBoxPreference : APreference<CheckBox, bool>
    {
        public CheckBoxPreference(string name, bool defaultValue) : base(name, defaultValue)
        { }

        public override bool ComponentValue
        {
            get => _component.IsChecked == true;
            set => _component.IsChecked = value;
        }
    }
}
