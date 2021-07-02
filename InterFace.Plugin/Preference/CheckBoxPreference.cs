using Avalonia.Controls;

namespace InterFace.Plugin.Preference
{
    public class CheckBoxPreference : APreference<CheckBox, bool>
    {
        public override bool Value
        {
            get => _component.IsChecked.Value;
            set => _component.IsChecked = value;
        }

        public CheckBoxPreference(string name, bool defaultValue) : base(name, defaultValue)
        { }
    }
}
