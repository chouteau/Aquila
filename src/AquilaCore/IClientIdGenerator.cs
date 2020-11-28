using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public interface IClientIdGenerator
	{
		string Name { get; }
		ClientInfo GetClientId(HttpContext httpContext);
	}
}
