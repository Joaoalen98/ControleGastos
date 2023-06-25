namespace BlazorWebApp.Servico
{
    public class ServicoException : Exception
    {
        public dynamic? Data { get; set; }

        public string Message { get; set; }

        public ServicoException(string msg, dynamic? data)
        {
            this.Message = msg;
            this.Data = data;
        }
    }
}
