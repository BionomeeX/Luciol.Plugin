using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin.Preference
{
    public interface IPreference<T>
    {
        public event EventHandler<PreferenceEventArgs<T>> OnChange;
    }
}
