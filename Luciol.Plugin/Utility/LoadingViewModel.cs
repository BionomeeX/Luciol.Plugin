using Avalonia.Threading;
using ReactiveUI;
using System.Reactive;

namespace Luciol.Plugin.Utility
{
    public class LoadingViewModel : ReactiveObject
    {
        internal void Close()
        {
            CloseInteraction.Handle(Unit.Default).Subscribe(Observer.Create<Unit>(_ => { }));
        }

        /// <summary>
        /// Close the window
        /// </summary>
        public Interaction<Unit, Unit> CloseInteraction { get; } = new();
        private double _progress;
        private string _text;

        /// <summary>
        /// Value of the progress bar
        /// </summary>
        internal double Progress
        {
            get => _progress;
            set => this.RaiseAndSetIfChanged(ref _progress, value);
        }
        /// <summary>
        /// Text displayed above the progress bar
        /// </summary>
        internal string Text
        {
            get => _text;
            set => this.RaiseAndSetIfChanged(ref _text, value);
        }

        public void SetProgress(string text, double value)
        {
            Progress = value;
            Text = text;
            CancellationTokenSource source = new();
            Task.Run(() =>
            {
                source.CancelAfter(100); // TODO: Probably not the best way to do that
            });
            Dispatcher.UIThread.MainLoop(source.Token);
            source.Dispose();
        }
    }
}
