namespace Luciol.Plugin.Context
{
    public record SNPData<T>
    {
        public T Value { init; get; }
        public uint ChPos { init; get; }
    }
}
