using Luciol.Plugin.Preference;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Luciol.Plugin.Context.Annotation
{
    public class GroupAnnotation : IAnnotation
    {
        public GroupAnnotation(int snp1Start, int snp1Stop, int snp2Start, int snp2Stop, int layer, [NotNull] APluginInfo pInfo, DrawType drawType, Color color, string name, Priority priority = Priority.Normal)
            => (Snp1Start, Snp1Stop, Snp2Start, Snp2Stop, Layer, Name, Sender, DrawType, Color, Priority)
            = (snp1Start, snp1Stop, snp2Start, snp2Stop, layer, name, pInfo.Key, drawType, color, priority);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Default ctor is for JSON serialization only", error: true)]
        public GroupAnnotation()
        { }

        /// <summary>
        /// Layer the annotation was placed on
        /// </summary>
        public int Layer { init; get; }
        /// <summary>
        /// First snip of the annotation (also equals to X position)
        /// </summary>
        public int Snp1Start { init; get; }
        public int Snp1Stop { init; get; }
        /// <summary>
        /// Second snip of the annotation (also equals to Y position)
        /// </summary>
        public int Snp2Start { init; get; }
        public int Snp2Stop { init; get; }
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

        public AnnotationType Type => AnnotationType.Group;

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
            => (Layer, Snp1Start, Snp1Stop, Snp2Start, Snp2Stop).GetHashCode();

        private bool Equals(GroupAnnotation other)
            => other != null && Layer == other.Layer &&
            Snp1Start == other.Snp1Start && Snp1Stop == other.Snp1Stop &&
            Snp2Start == other.Snp2Start && Snp2Stop == other.Snp2Stop && Key == other.Key;
    }
}
