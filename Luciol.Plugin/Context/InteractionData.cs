namespace Luciol.Plugin.Context
{
    public record InteractionData<T>
    {
        public T Value { init; get; }
        public uint ChPos { init; get; }
    }
}
