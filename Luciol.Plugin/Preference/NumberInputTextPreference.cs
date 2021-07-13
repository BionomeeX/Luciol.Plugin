using Avalonia.Controls;
using System;

namespace Luciol.Plugin.Preference
{
    public class NumberInputTextPreference<Type> : APreference<TextBox, Type>
        where Type : IConvertible
    {
        public NumberInputTextPreference(string key, string name, Type defaultValue) : base(key, name, defaultValue)
        { }

        protected override Type ComponentValue
        {
            get
            {
                if (_component.Text == null)
                {
                    return default;
                }
                try
                {
                    return (Type)Convert.ChangeType(_component.Text, typeof(Type));
                }
                catch (FormatException)
                {
                    return _value;
                }
            }
            set
            {
                var newValue = (Type)Convert.ChangeType(value, typeof(Type));
                _component.Text = newValue.ToString();
            }
        }
    }
}
