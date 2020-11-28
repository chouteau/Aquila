using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class DefaultTrack : TrackBuilder
	{
		public DefaultTrack(
			Settings settings,
			ILogger<TrackBuilder> logger,
			TrackSender trackSender,
			ClientIdFactory clientIdFactory)
			: base(settings, logger, trackSender, clientIdFactory)
		{

		}

		protected override string HitType
		{
			get { return "pageview"; }
		}
	}
}
