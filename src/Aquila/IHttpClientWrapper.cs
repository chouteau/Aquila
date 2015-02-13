using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public interface IHttpClientWrapper
	{
		Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
	}
}
