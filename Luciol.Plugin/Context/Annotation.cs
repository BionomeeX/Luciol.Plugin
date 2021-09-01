using System;
using System.ComponentModel;

namespace Luciol.Plugin.Context
{
    public class Annotation
    {
        internal Annotation(int snp1, int snp2, int layer, float value, AnnotationType type)
            => (Snp1, Snp2, Layer, Value, Type) = (snp1, snp2, layer, value, type);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Default ctor is for JSON serialization only", error: true)]
        public Annotation()
        { }

        /// <summary>
        /// Layer the annotation was placed on
        /// </summary>
        public int Layer { init; get; }
        /// <summary>
        /// First snip of the annotation (also equals to X position)
        /// </summary>
        public int Snp1 { init; get; }
        /// <summary>
        /// Second snip of the annotation (also equals to Y position)
        /// </summary>
        public int Snp2 { init; get; }
        /// <summary>
        /// Value of the annotation
        /// </summary>
        public float Value { init; get; }
        /// <summary>
        /// Type of the annotation
        /// </summary>
        public AnnotationType Type { init; get; }

        public static bool operator ==(Annotation a, Annotation b)
        {
            if (a is null)
            {
                return b is null; // True if a and b are null, else false
            }
            return a.Equals(b);
        }

        public static bool operator !=(Annotation a, Annotation b)
            => !(a == b);

        public override bool Equals(object obj)
            => Equals(obj as Annotation);

        public override int GetHashCode()
            => (Layer, Snp1, Snp2).GetHashCode();

        private bool Equals(Annotation other)
            => other != null && Layer == other.Layer && Snp1 == other.Snp1 && Snp2 == other.Snp2;
    }
}
