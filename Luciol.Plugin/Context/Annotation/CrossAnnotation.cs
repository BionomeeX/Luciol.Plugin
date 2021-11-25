using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Luciol.Plugin.Context.Annotation
{
    public class CrossAnnotation
    {
        public CrossAnnotation(int snp1, int snp2, int layer, [NotNull]APluginInfo pInfo, DrawType drawType, Color color, string type, Priority priority = Priority.Normal)
            => (Snp1, Snp2, Layer, Type, Sender, DrawType, Color, Priority)
            = (snp1, snp2, layer, pInfo.Key + type, pInfo.Key, drawType, color, priority);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Default ctor is for JSON serialization only", error: true)]
        public CrossAnnotation()
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
        /// Type of the annotation
        /// </summary>
        public string Type { init; get; }
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

        public static bool operator ==(CrossAnnotation a, CrossAnnotation b)
        {
            if (a is null)
            {
                return b is null; // True if a and b are null, else false
            }
            return a.Equals(b);
        }

        public static bool operator !=(CrossAnnotation a, CrossAnnotation b)
            => !(a == b);

        public override bool Equals(object obj)
            => Equals(obj as CrossAnnotation);

        public override int GetHashCode()
            => (Layer, Snp1, Snp2).GetHashCode();

        private bool Equals(CrossAnnotation other)
            => other != null && Layer == other.Layer && Snp1 == other.Snp1 && Snp2 == other.Snp2 && Type == other.Type;
    }
}
