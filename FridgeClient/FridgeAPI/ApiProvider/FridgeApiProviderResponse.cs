using System.Net;

namespace FridgeClient.FridgeAPI.ApiProvider
{
    public class FridgeApiProviderResponse<T> where T : class
    {
        public T Data { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }


        public FridgeApiProviderResponse()
        {
            Data = null;
        }
    }
}
