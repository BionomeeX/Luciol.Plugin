using Avalonia.Controls;
using System;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Input text preference but can only contains numbers
    /// </summary>
    /// <typeparam name="Type">The kind of number stored (int, float...)</typeparam>
    public class NumberInputTextPreference<Type> : APreference<TextBox, Type>
        where Type : IComparable<Type>, IEquatable<Type>
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
                    return Value;
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
