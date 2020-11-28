using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class ClientIdFactory
	{
		public ClientIdFactory(IEnumerable<IClientIdGenerator> generators,
			Settings settings)
		{
			this.ClientIdGenerators = generators;
			this.Settings = settings;
		}

		protected IEnumerable<IClientIdGenerator> ClientIdGenerators { get; }
		protected Settings Settings { get; }

		public ClientInfo GetClientInfo(HttpContext httpContext)
		{
			string generatorName = null;
			if (Settings.UseBrowserId)
			{
				generatorName = "BrowserId";
			}
			else
			{
				generatorName = "Cookie";
			}

			var generator = ClientIdGenerators.Single(i => i.Name == generatorName);
			return generator.GetClientId(httpContext);
		}
	}
}
