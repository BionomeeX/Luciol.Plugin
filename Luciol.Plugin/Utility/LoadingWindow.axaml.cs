using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Reactive;

namespace Luciol.Plugin.Utility
{
    public partial class LoadingWindow : ReactiveWindow<LoadingViewModel>
    {
        public static LoadingViewModel Show(Window parent, string baseText)
        {
            var vm = new LoadingViewModel();
            var window = new LoadingWindow
            {
                DataContext = vm
            };
            vm.Text = baseText;
            window.Show(parent);
            return vm;
        }

        public LoadingWindow()
        {
            AvaloniaXamlLoader.Load(this);
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(_ =>
            {
                ViewModel.CloseInteraction.RegisterHandler(Close);
            });
        }

        private Task Close(InteractionContext<Unit, Unit> interaction)
        {
            Close();
            interaction.SetOutput(Unit.Default);
            return Task.CompletedTask;
        }
    }
}
