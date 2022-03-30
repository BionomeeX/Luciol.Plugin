namespace Luciol.Plugin.Preference.Global
{
    public class GlobalSettings
    {
        internal GlobalSettings()
        { }

        public Settings General { get; } = new(Array.Empty<IPreferenceExport>());

        public TriangleSettings Triangle { get; } = new();

        public GraphSettings Graph { get; } = new();

        public AnnotationSettings Annotation { get; } = new();
    }
}
