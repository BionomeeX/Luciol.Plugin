using Luciol.Plugin.Core;
using Luciol.Plugin.Preference;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Luciol.Plugin.Context.Annotation
{
    /// <summary>
    /// Annotation used to represent a block of interactions on the triangle
    /// </summary>
    public class GroupAnnotation : IAnnotation
    {
        public GroupAnnotation(int snp1Start, int snp1Stop, int snp2Start, int snp2Stop, int layer, [NotNull] APluginInfo pInfo, DrawType drawType, Color color, string name, Priority priority = Priority.Normal)
            => (Snp1Start, Snp1Stop, Snp2Start, Snp2Stop, Layer, Name, Sender, DrawType, Color, Priority)
            = (snp1Start, snp1Stop, snp2Start, snp2Stop, layer, name, pInfo.Key, drawType, color, priority);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Default ctor is for JSON serialization only", error: true)]
        public GroupAnnotation()
        { }

        /// <inheritdoc/>
        public int Layer { init; get; }
        /// <summary>
        /// First SNP on the X position
        /// </summary>
        public int Snp1Start { init; get; }
        /// <summary>
        /// Last SNP on the X position
        /// </summary>
        public int Snp1Stop { init; get; }
        /// <summary>
        /// First SNP on the Y position
        /// </summary>
        public int Snp2Start { init; get; }
        /// <summary>
        /// Last SNP on the Y position
        /// </summary>
        public int Snp2Stop { init; get; }
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
        public AnnotationType Type => AnnotationType.Group;

        public override string ToString()
        {
            return $"{Name} ({Snp1Start};{Snp2Start}) ({Snp1Stop};{Snp2Stop})";
        }

        public static bool operator ==(GroupAnnotation a, GroupAnnotation b)
        {
            if (a is null)
            {
                return b is null; // True if a and b are null, else false
            }
            return a.Equals(b);
        }

        private string Key => $"{Sender}/{Name}";

        public static bool operator !=(GroupAnnotation a, GroupAnnotation b)
            => !(a == b);

        public override bool Equals(object obj)
            => Equals(obj as GroupAnnotation);

        public override int GetHashCode()
            => (Layer, Snp1Start, Snp1Stop, Snp2Start, Snp2Stop, Type).GetHashCode();

        private bool Equals(GroupAnnotation other)
            => other != null && Layer == other.Layer &&
            Snp1Start == other.Snp1Start && Snp1Stop == other.Snp1Stop &&
            Snp2Start == other.Snp2Start && Snp2Stop == other.Snp2Stop && Key == other.Key;

        public string ID => $"{(int)Type}{Layer}{Snp1Start}{Snp1Stop}{Snp2Start}{Snp2Stop}";
    }
}
