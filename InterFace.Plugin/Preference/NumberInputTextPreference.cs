using System.Linq;

namespace InterFace.Plugin.Preference
{
    public class NumberInputTextPreference : InputTextPreference
    {
        public override string Value
        {
            get => _component.Text;
            set
            {
                if (value.All(x => char.IsDigit(x)))
                {
                    if (value == "")
                    {
                        _component.Text = "0";
                    }
                    else
                    {
                        _component.Text = value.TrimStart('0');
                    }
                }
            }
        }

        public NumberInputTextPreference(string name, string defaultValue = "0") : base(name, defaultValue)
        { }
    }
}
