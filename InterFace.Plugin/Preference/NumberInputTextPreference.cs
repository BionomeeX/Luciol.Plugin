using Avalonia.Controls;
using System;

namespace InterFace.Plugin.Preference
{
    public class NumberInputTextPreference<Type> : APreference<TextBox, Type>
        where Type : IComparable<Type>
    {
        public NumberInputTextPreference(string name, Type defaultValue) : base(name, defaultValue)
        { }

        public override Type ComponentValue
        {
            get => (Type)Convert.ChangeType(_component.Text, typeof(Type));
            set
            {
                if (value.ToString() != _component.Text)
                {
                    try
                    {
                        var newValue = (Type)Convert.ChangeType(_component.Text, typeof(Type));
                        _component.Text = newValue.ToString();
                    }
                    catch (InvalidCastException)
                    { }
                }
            }
        }
    }
}
