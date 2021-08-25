namespace Luciol.Plugin.Context
{
    public class Annotation
    {
        public Annotation(int snp1, int snp2, int layer, float value)
            => (Snp1, Snp2, Layer, Value) = (snp1, snp2, layer, value);

        /// <summary>
        /// Layer the annotation was placed on
        /// </summary>
        public int Layer { get; }
        /// <summary>
        /// First snip of the annotation (also equals to X position)
        /// </summary>
        public int Snp1 { get; }
        /// <summary>
        /// Second snip of the annotation (also equals to Y position)
        /// </summary>
        public int Snp2 { get; }
        /// <summary>
        /// Value of the annotation
        /// </summary>
        public float Value { get; }

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
