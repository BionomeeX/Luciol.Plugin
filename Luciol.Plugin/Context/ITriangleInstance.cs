using Avalonia;
using System.Threading.Tasks;

namespace Luciol.Plugin.Context
{
    public interface ITriangleInstance
    {
        public int PixelSize { get; }
        public int CurrentZoom { get; }
    }
}
