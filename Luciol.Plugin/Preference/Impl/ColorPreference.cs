using Avalonia.Controls;
using ExtendedAvalonia;
using Luciol.Plugin.Context;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Color preference, store RGB values
    /// </summary>
    public class ColorPreference : APreference<RenderView, Color>
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
                int[][] data = new int[_height][];
                for (int y = 0; y < data.Length; y++)
                {
                    data[y] = Enumerable.Repeat(System.Drawing.Color.FromArgb(255, value.R, value.G, value.B).ToArgb(), _width).ToArray();
                }
                _component.RenderData = data;
            }
        }

        public override IControl GetComponent(Window window, IContext context)
        {
            var c = base.GetComponent(window, context); // We need to call that before because it init _component
            _component.Width = _width;
            _component.Height = _height;
            _component.Click += (sender, e) =>
            {
                var picker = ColorPicker.Show(window, Value);
                picker.OnCompletion += (pickerSender, color) =>
                {
                    UpdateValue(pickerSender, context, Color.FromRgb(color.Data.R, color.Data.G, color.Data.B));
                };
            };
            return c;
        }

        private const int _height = 15;
        private const int _width = 50;
    }
}
