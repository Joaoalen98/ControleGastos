using Newtonsoft.Json;

namespace BlazorWebApp.Servico
{
    public class ServicoException : Exception
    {
        public dynamic? Data { get; set; }

        public string Message { get; set; }

        public ServicoException(string msg, dynamic? data = null)
        {
            this.Message = msg;
            this.Data = data;
        }
    }

    public static class ServicoExceptionExtensions
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
