namespace Luciol.Plugin.Preference
{
    // Because somehow (de)serialization doesn't work properly for Color from System and Avalonia
    public class Color
    {
        public byte R { set; get; }
        public byte G { set; get; }
        public byte B { set; get; }

        /// <summary>
        /// Convert current color to System.Drawing.Color
        /// </summary>
        public System.Drawing.Color ToSystemColor()
        {
            return System.Drawing.Color.FromArgb(R, G, B);
        }

        /// <summary>
        /// Create a new color from its RGB values
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        public static Color FromRgb(byte r, byte g, byte b)
            => new()
            {
                R = r,
                G = g,
                B = b
            };

        public static Color Red { get; } = FromRgb(255, 0, 0);
        public static Color Green { get; } = FromRgb(0, 255, 0);
        public static Color Blue { get; } = FromRgb(0, 0, 255);
        public static Color Yellow { get; } = FromRgb(255, 255, 0);
        public static Color Magenta { get; } = FromRgb(255, 0, 255);
        public static Color Cyan { get; } = FromRgb(0, 255, 255);
        public static Color White { get; } = FromRgb(255, 255, 255);
        public static Color Black { get; } = FromRgb(0, 0, 0);
    }
}
