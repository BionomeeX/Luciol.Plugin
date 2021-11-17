using Avalonia.Controls;
using System.IO;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Input text preference representing a path on the computer
    /// </summary>
    public class PathInputTextPreference : APreference<TextBox, string>
    {
        public PathInputTextPreference(string key, string name, string defaultValue) : base(key, name, defaultValue)
        { }

        protected override string ComponentValue
        {
            get
            {
                if (_component.Text == null)
                {
                    return default;
                }
                if (!File.Exists(_component.Text))
                {
                    return Value;
                }
                return _component.Text;
            }
            set
            {
                if (File.Exists(value))
                {
                    _component.Text = value.ToString();
                }
            }
        }
    }
}
