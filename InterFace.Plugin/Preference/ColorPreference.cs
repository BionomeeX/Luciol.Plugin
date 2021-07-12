using Avalonia.Controls;
using Avalonia.Controls.Shapes;
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
                    return Color.FromUInt32(Convert.ToUInt32(text, 16));
                }
                catch (FormatException)
                {
                    return _value;
                }
            }
            set
            {
                _component.Text = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2");
            }
        }

        public override IControl GetComponent(IContext context)
        {
            var component = (StackPanel)base.GetComponent(context);
            component.Children.Add(new Rectangle
            {
                Fill = new SolidColorBrush
                {
                    Color = ComponentValue
                }
            });
            return component;
        }
    }
}
