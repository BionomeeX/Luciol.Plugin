using ReactiveUI;
using System.Reactive;

namespace Luciol.Plugin.Core
{
    public abstract class APluginViewModel : ReactiveObject
    {
        public APluginViewModel()
        {
            RxApp.DefaultExceptionHandler = Observer.Create<Exception>((e) =>
            {
                ErrorState?.Invoke(this, new());
            });
        }

        public virtual void Init(ADisplayPlugin plugin)
        { }

        internal event EventHandler ErrorState;
    }
}
