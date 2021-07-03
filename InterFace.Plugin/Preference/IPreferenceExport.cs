﻿using Avalonia.Controls;

namespace InterFace.Plugin.Preference
{
    public interface IPreferenceExport
    {
        public IControl GetComponent(IContext context);

        public string Key { get; }
        public object Value { set; get; }
    }
}
