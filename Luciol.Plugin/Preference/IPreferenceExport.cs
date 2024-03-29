﻿using Avalonia.Controls;
using Luciol.Plugin.Context;
using System.Text.Json.Serialization;

namespace Luciol.Plugin.Preference
{
    public interface IPreferenceExport
    {
        /// <summary>
        /// Get the Avalonia Control of the preference
        /// Contains the preference label and its component (checkbox, textbox, etc...)
        /// </summary>
        /// <param name="context">Global context, preference needs to access Save() methods when its modified</param>
        public IControl GetComponent(Window window, IContext context);

        /// <summary>
        /// Key of the preference, used to identify it
        /// <bold>Key must be unique within your plugin, also pay care to not change it between 2 releases</bold>
        /// If you don't follow this, user preferences may break
        /// </summary>
        public string Key { get; }
        /// <summary>
        /// Access to the value, used by the JSON deserialisation
        /// </summary>
        public object JsonValue { set; get; }
        /// <summary>
        /// Value in form of an object
        /// </summary>
        [JsonIgnore]
        public object ObjValue { set; get; }
    }
}
