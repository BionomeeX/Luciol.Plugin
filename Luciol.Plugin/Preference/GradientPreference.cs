using Avalonia.Controls;
using ExtendedAvalonia;
using ExtendedAvalonia.Slider;
using Luciol.Plugin.Context;
using System;
using System.Linq;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Gradient
    /// </summary>
    public class GradientPreference : APreference<RenderView, PositionColor[]>
    {
        public GradientPreference(string key, string name, PositionColor[] defaultValue) : base(key, name, defaultValue)
        { }

        protected override PositionColor[] ComponentValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                var rangeValue = Enumerable.Range(0, _width)
                    .Select(x => GradientPicker.GetColorFromPosition(value, (double)x / _width).ToArgb()).ToArray();

                int[][] data = new int[_height][];
                for (int y = 0; y < _height; y++)
                {
                    data[y] = rangeValue;
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
                GradientPicker.Show(window, (gradient) =>
                {
                    ComponentValue = gradient;
                    PropertyChanged(gradient);
                }, _value);
            };
            return c;
        }

        private const int _height = 15;
        private const int _width = 50;
    }
}
