using Luciol.Plugin.Core;
using Luciol.Plugin.Preference;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Luciol.Plugin.Context.Annotation
{
    /// <summary>
    /// Annotation used to represent a range of SNP
    /// </summary>
    public class RangeAnnotation : IAnnotation
    {
        public RangeAnnotation(int min, int max, int layer, [NotNull] APluginInfo pInfo, DrawType drawType, Color color, string name, Priority priority = Priority.Normal)
            => (Min, Max, Layer, Name, Sender, DrawType, Color, Priority)
            = (min, max, layer, name, pInfo.Key, drawType, color, priority);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Default ctor is for JSON serialization only", error: true)]
        public RangeAnnotation()
        { }

        /// <inheritdoc/>
        public int Layer { init; get; }
        /// <summary>
        /// First SNP
        /// </summary>
        public int Min { init; get; }
        /// <summary>
        /// Last SNP
        /// </summary>
        public int Max { init; get; }
        /// <inheritdoc/>
        public string Name { init; get; }
        /// <inheritdoc/>
        public string Sender { init; get; }
        /// <inheritdoc/>
        public DrawType DrawType { init; get; }
        /// <inheritdoc/>
        public Color Color { init; get; }
        /// <inheritdoc/>
        public Priority Priority { init; get; }
        /// <inheritdoc/>
        public bool IsActive { set; get; } = true;

        /// <inheritdoc/>
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
