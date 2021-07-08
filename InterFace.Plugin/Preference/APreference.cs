﻿using Avalonia.Controls;
using Avalonia.Layout;
using InterFace.Plugin.Event;
using System;

namespace InterFace.Plugin.Preference
{
    public abstract class APreference<Component, Type> : IPreferenceExport
        where Component : IControl, new()
    {
        /// <summary>
        /// Event called when the preference is changed
        /// </summary>
        public event EventHandler<PreferenceEventArgs<Type>> OnChange;

        /// <summary>
        /// Attribute used to modify the component on the view
        /// </summary>
        protected abstract Type ComponentValue { set; get; }
        /// <summary>
        /// Internal value stored for the component value
        /// Since component may reset if we close and reopen preference tab, we need to store it here
        /// </summary>
        protected Type _value { private set; get; }
        /// <summary>
        /// Default value of the preference
        /// </summary>
        private readonly Type _defaultValue;

        /// <inheritdoc/>
        public string Key { init; get; }
        /// <inheritdoc/>
        public string Name { init; get; }

        /// <inheritdoc/>
        public object Value
        {
            set
            {
                _value = (Type)Convert.ChangeType(value, typeof(Type));
            }
            get
            {
                return _value;
            }
        }

        /// <summary>
        /// Constructor for APreference
        /// </summary>
        /// <param name="key">Key of the preference</param>
        /// <param name="name">Text displayed on the preference label</param>
        /// <param name="defaultValue">Default value used for the preference</param>
        protected APreference(string key, string name, Type defaultValue)
            => (Key, Name, _defaultValue, _value) = (key, name, defaultValue, _defaultValue);

        /// <summary>
        /// Control used to store your preference
        /// </summary>
        protected Component _component;

        /// <inheritdoc/>
        public IControl GetComponent(IContext context)
        {
            // Create a new instance of the component and set its value to our current value saved
            _component = new();
            ComponentValue = _value;

            // When property is changed...
            _component.PropertyChanged += (sender, e) =>
            {
                _value = ComponentValue; // Set internal value to its current value
                OnChange?.Invoke(this, new PreferenceEventArgs<Type>(_value)); // Call event if someone registered to it
                context.SavedData.Save(); // Save change in file
            };

            // Stack panel containing our component and the explanation label
            var parent = new StackPanel
            {
                Orientation = Orientation.Horizontal // We put the label and the component next to each other
            };
            parent.Children.AddRange(new IControl[] // Add component and label inside the StackPanel
            {
                new Label()
                {
                    Content = Name
                },
                _component
            });
            return parent;
        }
    }
}
