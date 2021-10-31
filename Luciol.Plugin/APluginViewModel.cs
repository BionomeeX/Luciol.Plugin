using ReactiveUI;

namespace Luciol.Plugin
{
    public abstract class APluginViewModel : ReactiveObject
    {
        public virtual void Init(ADisplayPlugin plugin)
        { }
    }
}
