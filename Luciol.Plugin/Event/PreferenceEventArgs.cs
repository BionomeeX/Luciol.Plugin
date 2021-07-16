using System;

namespace Luciol.Plugin.Event
{
    /// <summary>
    /// Represent a setting event
    /// </summary>
    /// <typeparam name="T">Type of the setting</typeparam>
    public class PreferenceEventArgs<T> : EventArgs
    {
        public PreferenceEventArgs(T content)
            => Content = content;

        public T Content { init; get; }
    }
}
