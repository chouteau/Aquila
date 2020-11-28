using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class ClientInfo
	{
		public ClientInfo()
		{
			IsNewSession = false;
			Id = Guid.NewGuid().ToString();
		}
		public string Id { get; set; }
		public bool IsNewSession { get; set; }
	}
}
