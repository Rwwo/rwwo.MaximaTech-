namespace MaximaTech.App.Services
{
    public static class StringExtensions
    {
        public static string RemoveQuotes(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Replace("\"", "");
        }
    }
}
