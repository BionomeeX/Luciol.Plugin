namespace Luciol.Plugin.Preference
{
    public class ColorPalette : IEquatable<ColorPalette>
    {
        public Color[] Colors
        {
            set
            {
                if (value == null)
                {
                    _colors = Array.Empty<Color>();
                }
                else
                {
                    _colors = value;
                }
            }
            get
            {
                return _colors;
            }
        }

        private Color[] _colors = Array.Empty<Color>();

        public bool Equals(ColorPalette other)
        {
            if (other is null)
            {
                return false;
            }
            return other.Colors.SequenceEqual(Colors);
        }
    }
}
