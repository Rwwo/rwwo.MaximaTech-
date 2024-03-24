using System.Net;

namespace MaximaTech.App.Services
{
    public class GenericSimpleResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Json { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
