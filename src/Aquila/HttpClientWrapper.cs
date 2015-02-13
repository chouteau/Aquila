using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	internal class HttpClientWrapper : IHttpClientWrapper, IDisposable
	{
		readonly HttpClient m_HttpClient;

		public HttpClientWrapper()
		{
			m_HttpClient = new HttpClient();
		}

		public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, string ua = null)
		{
			m_HttpClient.DefaultRequestHeaders.Add("UserAgent", ua ?? "Aquila/3.1.7 (+https://github.com/chouteau/Aquila)");
			return await m_HttpClient.PostAsync(requestUri, content);
		}

		public void Dispose()
		{
			if (m_HttpClient != null)
			{
				m_HttpClient.Dispose();
			}
		}
	}
}
