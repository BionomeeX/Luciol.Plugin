﻿namespace Luciol.Plugin.Context.Triangle
{
    // TODO: Explain difference with InteractionData
    public record SemiInteractionData<T>
    {
        public T Value { init; get; }
        public uint ChPos { init; get; }
    }
}
