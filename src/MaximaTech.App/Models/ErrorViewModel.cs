namespace MaximaTech.App.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ErroGenericoViewModel
    {
        public string Mensagem { get; set; }

    }
}
