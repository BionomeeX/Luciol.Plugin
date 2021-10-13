using Avalonia.Controls;
using Luciol.Plugin.Context;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Color palette preference, represents an array of color
    /// </summary>
    public class ColorPalettePreference : APreference<TextBlock, ColorPalette>
    {
        public ColorPalettePreference(string key, string name, ColorPalette defaultValue) : base(key, name, defaultValue)
        { }

        protected override ColorPalette ComponentValue
        {
            get => Value;
            set { }
        }

        public override IControl GetComponent(Window window, IContext context)
        {
            var c = base.GetComponent(window, context); // We need to call that before because it init _component
            _component.Text = "Preference not editable yet";
            return c;
        }
    }
}
