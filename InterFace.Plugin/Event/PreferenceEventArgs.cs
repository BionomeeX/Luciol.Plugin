using System;

namespace InterFace.Plugin.Event
{
    public class PreferenceEventArgs<T> : EventArgs
    {
        public T Content;
    }
}
