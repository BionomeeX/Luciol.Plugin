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
                    _component.Text = value;
                }
            }
        }

        public NumberInputTextPreference(string name) : base(name)
        { }
    }
}
