using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Threading;
using Luciol.Plugin.Context;
using System;
using System.IO;

namespace Luciol.Plugin.Preference
{
    /// <summary>
    /// Input text preference representing a path on the computer
    /// </summary>
    public class PathInputTextPreference : APreference<TextBox, string>
    {
        public PathInputTextPreference(string key, string name, string defaultValue) : base(key, name, defaultValue)
        { }

        protected override string ComponentValue
        {
            get
            {
                if (_component.Text == null)
                {
                    return default;
                }
                if (!File.Exists(_component.Text))
                {
                    return Value;
                }
                return _component.Text;
            }
            set
            {
                if (File.Exists(value))
                {
                    _component.Text = value.ToString();
                }
            }
        }

        public override IControl GetComponent(Window window, IContext context)
        {
            var textfield = base.GetComponent(window, context);
            StackPanel stack = new()
            {
                Orientation = Orientation.Horizontal
            };
            var button =
                new Button()
                {
                    Content = "Browse"
                };
            button.Click += (sender, e) =>
            {
                var dialog = new OpenFileDialog
                {
                    Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                dialog.ShowAsync(window).ContinueWith(async (s) =>
                {
                    var files = await s.ConfigureAwait(false);
                    if (files.Length > 0)
                    {
                        Dispatcher.UIThread.Post(() =>
                        {
                            UpdateValue(this, context, files[0]);
                        });
                    }
                });
            };
            stack.Children.AddRange(new IControl[]
            {
                textfield,
                button
            });
            return stack;
        }
    }
}
