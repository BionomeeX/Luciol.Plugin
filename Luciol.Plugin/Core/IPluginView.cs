using Avalonia.Controls;

namespace Luciol.Plugin.Core
{
    public interface IPluginView
    {
        public void Init(ADisplayPlugin plugin);

        internal Control Copy();

        internal object? ViewModel { set; get; }
        internal ADisplayPlugin Plugin { set; }
    }
}
