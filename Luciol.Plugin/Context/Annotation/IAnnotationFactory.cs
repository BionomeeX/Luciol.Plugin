namespace Luciol.Plugin.Context.Annotation
{
    public interface IAnnotationFactory
    {
        public CrossAnnotation CreateAnnotation(int snp1, int snp2, int layer);
    }
}
