namespace Luciol.Plugin.Preference.Global
{
    public class GlobalSettings
    {
        internal GlobalSettings()
        { }

        public TriangleSettings Triangle { get; } = new();

        public GraphSettings Graph { get; } = new();

        public AnnotationSettings Annotation { get; } = new();
    }
}
