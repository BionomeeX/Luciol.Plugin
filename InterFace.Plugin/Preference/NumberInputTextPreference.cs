using Avalonia.Controls;
using System;
using System.Linq;

namespace InterFace.Plugin.Preference
{
    public class NumberInputTextPreference<Type> : APreference<TextBox, Type>
        where Type : IComparable<Type>
    {
        public override Type Value
        {
            get => (Type)Convert.ChangeType(_component.Text, typeof(Type));
            set
            {
                try
                {
                    var res = Convert.ChangeType(value, typeof(Type));
                    _component.Text = res.ToString();
                }
                catch (InvalidCastException)
                { }
            }
        }

        public NumberInputTextPreference(string name, Type defaultValue) : base(name, defaultValue)
        { }
    }
}
