using Microsoft.AspNetCore.WebUtilities;

namespace FridgeClient.ViewModels.Home
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }

        public string StatusCodeDescription { get; set; }

        public string Message { get; set; }

        public string ShortDescription
        {
            get { return $"Status Code: {StatusCode} - {StatusCodeDescription}"; }
        }
    }
}