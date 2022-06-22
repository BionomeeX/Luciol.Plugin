namespace Luciol.Plugin.Context.Deserialization
{
    /// <summary>
    /// Data about triangle, from FileClustering
    /// </summary>
    public class TriangleInfo
    {
        public string Id { init; get; }
        public int Ppf { init; get; }
        public IEnumerable<LayerInfo> Layers { init; get; }
        public Dictionary<string, MaxValueInfo> Info { init; get; }
    }
}
