using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class DefaultTrack : TrackBuilder
	{
		public DefaultTrack() : base()
		{

		}

		protected override string HitType
		{
			get { return "pageview"; }
		}
	}
}
