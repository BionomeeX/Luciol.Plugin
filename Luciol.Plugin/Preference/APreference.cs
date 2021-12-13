using Avalonia.Controls;
using Avalonia.Layout;
using Luciol.Plugin.Context;
using Luciol.Plugin.Event;
using System;
using System.Text.Json;

namespace Luciol.Plugin.Preference
{
    public abstract class APreference<Component, Type> : IPreferenceExport
        where Component : IControl, new()
        where Type : IEquatable<Type>
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
        public Type Value { private set; get; }
        /// <summary>
        /// Default value of the preference
        /// </summary>
        private readonly Type _defaultValue;

        /// <inheritdoc/>
        public string Key { init; get; }
        /// <inheritdoc/>
        public string Name { init; get; }

        /// <inheritdoc/>
        public object JsonValue
        {
            set
            {
                Value = JsonSerializer.Deserialize<Type>(((JsonElement)value).GetRawText());
            }
            get
            {
                return Value;
            }
        }

        /// <inheritdoc/>
        public object ObjValue
        {
            set
            {
                Value = (Type)value;
            }
            get
            {
                return Value;
            }
        }

        public void Reset(object sender, IContext context)
        {
            UpdateValue(sender, context, _defaultValue);
        }

        /// <summary>
        /// Constructor for APreference
        /// </summary>
        /// <param name="key">Key of the preference</param>
        /// <param name="name">Text displayed on the preference label</param>
        /// <param name="defaultValue">Default value used for the preference</param>
        protected APreference(string key, string name, Type defaultValue)
            => (Key, Name, _defaultValue, Value) = (key, name, defaultValue, defaultValue);

        /// <summary>
        /// Control used to store your preference
        /// </summary>
        protected Component _component = new();

        private IContext _context;

        public void UpdateValue(object sender, IContext context, Type value)
        {
            _context = context;
            if (!value.Equals(Value))
            {
                ComponentValue = value;
                PropertyChanged(sender, value);
            }
        }

        protected void PropertyChanged(object sender, Type value)
        {
            Value = value; // Set internal value to its current value
            _context.SavedData.Save(); // Save change in file
            _context.SavedData.OnSaved += (s, e) => // We call "OnChange" only when data are actually saved
            {
                OnChange?.Invoke(sender, new PreferenceEventArgs<Type>(Value)); // Call event if someone registered to it
            };
        }

        /// <summary>
        /// Default property to watch over
        /// </summary>
        protected virtual string PropertyWatchOver() => "Text";

        /// <inheritdoc/>
        public virtual IControl GetComponent(Window window, IContext context)
        {
            _context = context; // TODO: Move that to ctor

            // Create a new instance of the component and set its value to our current value saved
            _component = new();
            ComponentValue = Value;

            // When property is changed...
            _component.PropertyChanged += (sender, e) =>
            {
                if (e.Property.Name == PropertyWatchOver())
                {
                    PropertyChanged(sender, ComponentValue);
                }
            };

            // Stack panel containing our component and the explanation label
            var parent = new StackPanel
            {
                Orientation = Orientation.Horizontal // We put the label and the component next to each other
            };
            parent.Children.AddRange(new IControl[] // Add component and label inside the StackPanel
            {
                new Label
                {
                    Content = Name
                },
                _component
            });
            return parent;
        }
    }
}
