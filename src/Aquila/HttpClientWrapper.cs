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
		public HttpClientWrapper()
		{
		}

		public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, string ua = null)
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Add("UserAgent", ua ?? "Aquila/3.1.7 (+https://github.com/chouteau/Aquila)");
			return await httpClient.PostAsync(requestUri, content);
		}

		public void Post(string requestUri, HttpContent content, string ua = null)
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Add("UserAgent", ua ?? "Aquila/3.1.7 (+https://github.com/chouteau/Aquila)");
			var response = httpClient.PostAsync(requestUri, content);
			var result = response.Result;
			if (result.StatusCode != System.Net.HttpStatusCode.OK)
			{
				var errorMessage = "Fail to send track" + System.Environment.NewLine;
				errorMessage = errorMessage + "content:" + result.Content.ReadAsStringAsync().Result + System.Environment.NewLine;
				foreach (var header in result.Headers)
				{
					errorMessage = errorMessage + "key" + header.Key + "=" + header.Value + System.Environment.NewLine;
				}
				GlobalConfiguration.Configuration.Logger.Error(errorMessage);
			}
		}

		public void Dispose()
		{
		}
	}
}
