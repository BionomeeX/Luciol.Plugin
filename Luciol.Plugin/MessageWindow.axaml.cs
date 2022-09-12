using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Luciol.Plugin
{
    public partial class MessageWindow : Window
    {
        private static Window Parent => ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow;

        public static void Show(string message, Action callback)
        {
            var window = new MessageWindow();
            var ok = new Button
            {
                Content = "Ok"
            };
            ok.Click += (sender, e) =>
            {
                callback?.Invoke();
                window.Close();
            };
            window.FindControl<StackPanel>("Buttons").Children.Add(ok);
            window.Closed += (sender, e) =>
            {
                callback?.Invoke();
            };
            window.FindControl<TextBlock>("Description").Text = message;
            window.Show(Parent);
        }

        public static void ShowYesNo(string message, Action callbackYes, Action callbackNo)
        {
            var window = new MessageWindow();
            var yes = new Button
            {
                Content = "Yes"
            };
            var no = new Button
            {
                Content = "No"
            };
            yes.Click += (sender, e) =>
            {
                callbackYes?.Invoke();
                window.Close();
            };
            no.Click += (sender, e) =>
            {
                callbackNo?.Invoke();
                window.Close();
            };
            window.FindControl<StackPanel>("Buttons").Children.AddRange(new[] { yes, no });
            window.Closed += (sender, e) =>
            {
                callbackNo?.Invoke();
            };
            window.FindControl<TextBlock>("Description").Text = message;
            window.Show(Parent);
        }

        public MessageWindow()
        {
            AvaloniaXamlLoader.Load(this);
#if DEBUG
            this.AttachDevTools();
#endif
        }
    }
}
