using Avalonia.Controls;
using ExtendedAvalonia;
using Luciol.Plugin.Context;
using System;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Color preference, store RGB values
    /// </summary>
    public class ColorPreference : APreference<Button, Color>
    {
        public ColorPreference(string key, string name, Color defaultValue) : base(key, name, defaultValue)
        { }

        protected override Color ComponentValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                _component.Background = new Avalonia.Media.SolidColorBrush(Avalonia.Media.Color.FromRgb(value.R, value.G, value.B));
            }
        }

        public override IControl GetComponent(IContext context)
        {
            var c = base.GetComponent(context); // We need to call that before because it init _component
            _component.Width = 50;
            _component.Height = 15;
            _component.Click += (sender, e) =>
            {
                ColorPicker.Show(null, (color) =>
                {
                    PropertyChanged(Color.FromRgb(color.R, color.G, color.B));
                });
            };
            return c;
        }
    }
}
