using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin.Preference
{
    interface IPreference<T> : IPreferenceExport
    {
        public event EventHandler<PreferenceEventArgs<T>> OnChange;

        public T Value { set; get; }
    }
}
