using System.Collections.Generic;
using System.Drawing;

namespace Luciol.Plugin.Context.Annotation
{
    public interface ITriangleContext
    {
        public IEnumerable<string> GetOptions();
        public void Enable(string key);
        public void Disable(string key);
        public Color GetValue(float value, float maxValue);
    }
}
