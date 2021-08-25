namespace Luciol.Plugin.SaveLoad
{
    public interface ICustomData
    {
        public object ExportData { get; }
        public void Init(object data);
    }
}
