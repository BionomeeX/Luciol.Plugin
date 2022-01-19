using Luciol.Plugin.Preference;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Luciol.Plugin.Context.Annotation
{
    public class RangeAnnotation : IAnnotation
    {
        public RangeAnnotation(int min, int max, int layer, [NotNull] APluginInfo pInfo, DrawType drawType, Color color, string name, Priority priority = Priority.Normal)
            => (Min, Max, Layer, Name, Sender, DrawType, Color, Priority)
            = (min, max, layer, name, pInfo.Key, drawType, color, priority);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Default ctor is for JSON serialization only", error: true)]
        public RangeAnnotation()
        { }

        /// <summary>
        /// Layer the annotation was placed on
        /// </summary>
        public int Layer { init; get; }
        public int Min { init; get; }
        public int Max { init; get; }
        /// <summary>
        /// Type of the annotation
        /// </summary>
        public string Name { init; get; }
        /// <summary>
        /// Plugin that annotation is from
        /// </summary>
        public string Sender { init; get; }
        /// <summary>
        /// How the annotation will be drawn on the main triangle
        /// </summary>
        public DrawType DrawType { init; get; }
        public Color Color { init; get; }
        public Priority Priority { init; get; }

        public AnnotationType Type => AnnotationType.Range;

        public override string ToString()
        {
            return $"{Name} {Min} to {Max}";
        }

        public static bool operator ==(RangeAnnotation a, RangeAnnotation b)
        {
            if (a is null)
            {
                return b is null; // True if a and b are null, else false
            }
            return a.Equals(b);
        }

        private string Key => $"{Sender}/{Name}";

        public static bool operator !=(RangeAnnotation a, RangeAnnotation b)
            => !(a == b);

        public override bool Equals(object obj)
            => Equals(obj as RangeAnnotation);

        public override int GetHashCode()
            => (Layer, Min, Max).GetHashCode();

        private bool Equals(RangeAnnotation other)
            => other != null && Layer == other.Layer && Min == other.Min && Max == other.Max && Key == other.Key;
    }
}
