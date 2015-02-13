using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class PageTrack : TrackBuilder
	{
		public PageTrack() : base()
		{

		}

		public PageTrack(System.Web.HttpContextBase ctx)
			: base(ctx)
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

	}
}
