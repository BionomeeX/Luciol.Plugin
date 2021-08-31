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
            => a.Layer == b.Layer && a.Snp1 == b.Snp1 && a.Snp2 == b.Snp2;

        public static bool operator !=(Annotation a, Annotation b)
            => a.Layer != b.Layer || a.Snp1 != b.Snp1 || a.Snp2 != b.Snp2;

        public override bool Equals(object obj)
        {
            var ann = obj as Annotation;
            return ann != null && ann == this;
        }

        public override int GetHashCode()
            => (Layer, Snp1, Snp2).GetHashCode();
    }
}
