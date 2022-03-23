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
                ;
            });
        }

        public virtual void Init(ADisplayPlugin plugin)
        { }
    }
}
