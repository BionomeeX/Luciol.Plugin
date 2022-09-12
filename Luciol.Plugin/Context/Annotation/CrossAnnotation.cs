using Luciol.Plugin.Core;
using Luciol.Plugin.Preference;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Luciol.Plugin.Context.Annotation
{
    /// <summary>
    /// Annotation used to represent one interaction on the triangle
    /// </summary>
    public class CrossAnnotation : IAnnotation
    {
        public CrossAnnotation(int snp1, int snp2, int layer, [NotNull]APluginInfo pInfo, DrawType drawType, Color color, string name, Priority priority = Priority.Normal)
            => (Snp1, Snp2, Layer, Name, Sender, DrawType, Color, Priority)
            = (snp1, snp2, layer, name, pInfo.Key, drawType, color, priority);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Default ctor is for JSON serialization only", error: true)]
        public CrossAnnotation()
        { }

        /// <inheritdoc/>
        public int Layer { init; get; }
        /// <summary>
        /// First SNP of the annotation (also equals to X position)
        /// </summary>
        public int Snp1 { init; get; }
        /// <summary>
        /// Second SNP of the annotation (also equals to Y position)
        /// </summary>
        public int Snp2 { init; get; }
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
        public AnnotationType Type => AnnotationType.Cross;

        public override string ToString()
        {
            return $"{Name} ({Snp1};{Snp2})";
        }

        public static bool operator ==(CrossAnnotation a, CrossAnnotation b)
        {
            if (a is null)
            {
                return b is null; // True if a and b are null, else false
            }
            return a.Equals(b);
        }

        private string Key => $"{Sender}/{Name}";

        public static bool operator !=(CrossAnnotation a, CrossAnnotation b)
            => !(a == b);

        public override bool Equals(object obj)
            => Equals(obj as CrossAnnotation);

        public override int GetHashCode()
            => (Layer, Snp1, Snp2, Type).GetHashCode();

        private bool Equals(CrossAnnotation other)
            => other != null && Layer == other.Layer && Snp1 == other.Snp1 && Snp2 == other.Snp2 && Key == other.Key;

        public string ID => $"{(int)Type}{Layer}{Snp1}{Snp2}";
    }
}
