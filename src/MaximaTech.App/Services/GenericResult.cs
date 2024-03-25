namespace MaximaTech.App.Services
{
    public class GenericResult<TResult> : GenericSimpleResult
    {
        public TResult Result { get; set; }
    }
}
