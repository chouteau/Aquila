using System.Net.Http;
using System.Threading.Tasks;

namespace Aquila
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, string userAgent = null);

        void Post(string requestUri, HttpContent content, string userAgent = null);
    }
}