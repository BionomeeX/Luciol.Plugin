using System.Collections.Generic;

namespace Luciol.Plugin.Context.Annotation
{
    public interface ITriangleContext
    {
        public IEnumerable<string> GetOptions();
        public void Enable(string key);
        public void Disable(string key);
        public void GetValue(float value, float maxValue);
    }
}
