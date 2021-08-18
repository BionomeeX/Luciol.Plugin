using System.Text.Json;

namespace Luciol.Plugin.SaveLoad
{
    public class CustomData<T> : ICustomData
    {
        public T Data { private set; get; }

        public object ExportData => Data;

        public void Init(object data)
        {
            Data = JsonSerializer.Deserialize<T>(((JsonElement)data).GetRawText());
        }

        void ICustomData.Init(object data)
        {
            throw new System.NotImplementedException();
        }
    }
}
