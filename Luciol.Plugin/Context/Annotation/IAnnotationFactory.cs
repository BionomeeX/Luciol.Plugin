namespace Luciol.Plugin.Context.Annotation
{
    public interface IAnnotationFactory
    {
        public IAnnotation CreateAnnotation(int snp1, int snp2, int layer);
    }
}
