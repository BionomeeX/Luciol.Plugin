namespace Luciol.Plugin.Context.EpistaticMap
{
    // TODO: Explain difference with InteractionData
    public record SemiInteractionData<T>
    {
        public T Value { init; get; }
        public long ChPos { init; get; }
    }
}
