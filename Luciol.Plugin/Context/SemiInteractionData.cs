namespace Luciol.Plugin.Context
{
    public record SemiInteractionData<T>
    {
        public T Value { init; get; }
        public uint ChPos { init; get; }
    }
}
