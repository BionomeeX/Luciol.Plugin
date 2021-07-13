using System;

namespace Luciol.Plugin.Event
{
    public class PreferenceEventArgs<T> : EventArgs
    {
        public PreferenceEventArgs(T content)
            => Content = content;

        public T Content { init; get; }
    }
}
