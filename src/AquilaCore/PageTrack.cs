using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class PageTrack : TrackBuilder
	{
		public PageTrack(
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

		public string Url
		{
			get
			{
				return m_Track.DocumentLocationUrl;
			}
			set
			{
				m_Track.DocumentLocationUrl = value;
			}
		}

		public string PathAndQuery
		{
			get
			{
				return m_Track.DocumentPath;
			}
			set
			{
				m_Track.DocumentPath = value;
			}
		}

		public string Title
		{
			get
			{
				return m_Track.DocumentTitle;
			}
			set
			{
				m_Track.DocumentTitle = value;
			}
		}

		public string HostName
		{
			get
			{
				return m_Track.DocumentHostName;
			}
			set
			{
				m_Track.DocumentHostName = value;
			}
		}

		public override string Referer
		{
			get
			{
				return m_Track.DocumentReferer;
			}
			set
			{
				m_Track.DocumentReferer = value;
			}
		}
	}
}
