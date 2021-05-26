using Avalonia.Controls;
using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin.Preference
{
    public class CheckBoxPreference : IPreference<bool>
    {
        public event EventHandler<PreferenceEventArgs<bool>> OnChange;

        private CheckBox _component;
    }
}
