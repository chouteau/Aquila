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
			m_HttpClient.DefaultRequestHeaders.Add("UserAgent", "TransparentAnalytics/1.0 (+https://developers.google.com)");
		}

		public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
		{
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
