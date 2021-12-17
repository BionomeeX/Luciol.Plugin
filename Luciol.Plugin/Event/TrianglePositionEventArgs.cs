using System;

namespace Luciol.Plugin.Event
{
    public class TrianglePositionEventArgs : EventArgs
    {
        public TrianglePositionEventArgs(int snp1, int snp2, int layer)
            => (Snp1, Snp2, Layer) = (snp1, snp2, layer);

        public int Snp1 { init; get; }
        public int Snp2 { init; get; }
        public int Layer { init; get; }
    }
}
