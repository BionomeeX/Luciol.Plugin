using Avalonia.Controls;
using Avalonia.Media;
using System;

namespace InterFace.Plugin.Preference
{
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
                    var text = _component.Text;
                    if (text.StartsWith("#"))
                    {
                        text = text[1..];
                    }
                    var color = Color.FromUInt32(Convert.ToUInt32("FF" + text, 16));
                    if (_colorPreview != null)
                    {
                        _colorPreview.Background = new SolidColorBrush(color);
                    }
                    return color;
                }
                catch (ArgumentOutOfRangeException)
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
            _colorPreview = new TextBox
            {
                IsReadOnly = true,
                Background = new SolidColorBrush(ComponentValue)
            };
            component.Children.Add(_colorPreview);
            return component;
        }
    }
}
