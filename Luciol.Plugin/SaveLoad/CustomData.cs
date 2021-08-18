using System.Text.Json;

namespace Luciol.Plugin.SaveLoad
{
    public class CustomData<T> : ICustomData
        where T : new()
    {
        public T Data { private set; get; }

        public object ExportData => Data;

        public void Init(object data)
        {
            if (data != null)
            {
                Data = JsonSerializer.Deserialize<T>(((JsonElement)data).GetRawText());
            }
            else
            {
                Data = new();
            }
        }
    }
}
