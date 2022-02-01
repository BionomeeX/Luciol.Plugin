using Avalonia.Controls;

namespace Luciol.Plugin
{
    public interface IPluginView
    {
        public void Init(ADisplayPlugin plugin);

        internal Window Copy();

        internal object? ViewModel { set; get; }
        internal ADisplayPlugin Plugin { set; }
    }
}
