using Avalonia.Controls;
using Luciol.Plugin.Context;
using System;
using System.Globalization;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Color preference, store RGB values
    /// </summary>
    public class ColorPreference : APreference<TextBox, Color>
    {
        public ColorPreference(string key, string name, Color defaultValue) : base(key, name, defaultValue)
        { }

        protected override Color ComponentValue
        {
            get
            {
                if (_component.Text == null)
                {
                    return default;
                }
                try
                {
                    // Try to parse the hex value written
                    var text = _component.Text;
                    if (text.StartsWith("#")) // Remove the # at the start if there is one
                    {
                        text = text[1..];
                    }

                    // Parse the RGB values written in hex
                    var r = byte.Parse(text[0..2], NumberStyles.AllowHexSpecifier);
                    var g = byte.Parse(text[2..4], NumberStyles.AllowHexSpecifier);
                    var b = byte.Parse(text[4..6], NumberStyles.AllowHexSpecifier);
                    if (_colorPreview != null) // If the component that preview the color is set
                    {
                        _colorPreview.Background = new Avalonia.Media.SolidColorBrush(Avalonia.Media.Color.FromRgb(r, g, b));
                    }
                    return new Color
                    {
                        R = r,
                        G = g,
                        B = b
                    };
                }
                catch (ArgumentOutOfRangeException) // Invalid color written, we used the last one valid that was set
                {
                    return _value;
                }
            }
            set
            {
                _component.Text = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2");
            }
        }

        private TextBox _colorPreview;

        public override IControl GetComponent(IContext context)
        {
            var component = (StackPanel)base.GetComponent(context);
            var color = ComponentValue;
            _colorPreview = new TextBox // Textbox that preview the color by changing its background
            {
                IsReadOnly = true,
                Background = new Avalonia.Media.SolidColorBrush(Avalonia.Media.Color.FromRgb(color.R, color.G, color.B))
            };
            component.Children.Add(_colorPreview);
            return component;
        }
    }
}
