using System;
using System.Net;
using System.Threading.Tasks;

namespace Aquila.Tests
{
    public class MockHttpClientWrapper : IHttpClientWrapper
	{
		private Action<string, System.Net.Http.HttpContent> m_Action;

		public MockHttpClientWrapper(Action<string, System.Net.Http.HttpContent> action)
		{
			m_Action = action;
		}

		public Task<System.Net.Http.HttpResponseMessage> PostAsync(string requestUri, System.Net.Http.HttpContent content, string userAgent = null)
		{
			m_Action.Invoke(requestUri, content);

			var response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.OK);
			response.Content = content;
			return Task.FromResult(response);
		}

		public void Post(string requestUri, System.Net.Http.HttpContent content, string userAgent = null)
		{
			m_Action.Invoke(requestUri, content);
		}
	}
}
