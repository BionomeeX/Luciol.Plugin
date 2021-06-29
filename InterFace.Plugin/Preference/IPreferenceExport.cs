using Avalonia.Controls;

namespace InterFace.Plugin.Preference
{
    public interface IPreferenceExport
    {
        public IControl GetComponent();

        public string Name { get; }
    }
}
