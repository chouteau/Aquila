using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public abstract class TrackBuilder
	{
		internal Track m_Track;

		public TrackBuilder()
		{
			m_Track = new Track();
			Campaign = new Campaign(m_Track);
		}

		public TrackBuilder(System.Web.HttpContextBase ctx)
		{
			bool isNewSession = false;
			var clientId = ctx.GetOrSetClientId(GlobalConfiguration.Configuration.Settings.CookieName, out isNewSession);

			GlobalConfiguration.ConfigureMapping();

			m_Track = AutoMapper.Mapper.Map<System.Web.HttpContextBase, Track>(ctx, m_Track);
			if (m_Track.ClientId == null)
			{
				m_Track.ClientId = clientId;
				m_Track.SessionControl = "start";
			}
		}

		protected abstract string HitType { get; }

		protected virtual void ConfigureTrack()
		{
			m_Track.ProtocolVersion = "1";
			m_Track.TrackingId = m_Track.TrackingId ?? GlobalConfiguration.Configuration.Settings.TrackingId;
			m_Track.CurrencyCode = m_Track.CurrencyCode ?? GlobalConfiguration.Configuration.Settings.CurrencyCode;
		}

		public bool NonInteraction
		{
			get
			{
				return m_Track.NonInteractionHit;
			}
			set
			{
				m_Track.NonInteractionHit = value;
			}
		}

		public bool AnonymizeIp
		{
			get
			{
				return m_Track.AnonymizeIp;
			}
			set
			{
				m_Track.AnonymizeIp = value;
			}
		}

		public string TrackingId
		{
			get
			{
				return m_Track.TrackingId;
			}
			set
			{
				m_Track.TrackingId = value;
			}
		}

		public string ClientId
		{
			get
			{
				return m_Track.ClientId;
			}
			set
			{
				m_Track.ClientId = value;
			}
		}

		public string UserId
		{
			get
			{
				return m_Track.UserId;
			}
			set
			{
				m_Track.UserId = value;
			}
		}

		public string UserAgentOverride
		{
			get
			{
				return m_Track.UserAgentOverride;
			}
			set
			{
				m_Track.UserAgentOverride = value;
			}
		}

		public string IPOverride
		{
			get
			{
				return m_Track.IPOverride;
			}
			set
			{
				m_Track.IPOverride = value;
			}
		}

		public string Referer
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

		public Campaign Campaign { get; private set;  }

		public virtual async Task SendAsync()
		{
			ConfigureTrack();
			if (m_Track.TrackingId == null)
			{
				throw new Exception("TrackingId not configured");
			}
			m_Track.HitType = HitType;
			var httpContent = m_Track.GetBody();
			await GlobalConfiguration.Configuration.HttpClientWrapper.PostAsync(GlobalConfiguration.Configuration.Settings.UrlEndPoint, httpContent).ContinueWith(task =>
			{
				if (task.IsFaulted)
				{
					GlobalConfiguration.Configuration.Logger.Error(task.Exception);
				}
			});
		}

		internal virtual async Task SendAsync(Track track)
		{
			var httpContent = track.GetBody();
			await GlobalConfiguration.Configuration.HttpClientWrapper.PostAsync(GlobalConfiguration.Configuration.Settings.UrlEndPoint, httpContent, track.UserAgentOverride).ContinueWith(task =>
			{
				if (task.IsFaulted)
				{
					GlobalConfiguration.Configuration.Logger.Error(task.Exception);
				}
			});
		}

		public virtual void Send()
		{
			ConfigureTrack();
			if (m_Track.TrackingId == null)
			{
				throw new Exception("TrackingId not configured");
			}
			m_Track.HitType = HitType;
			var httpContent = m_Track.GetBody();
			GlobalConfiguration.Configuration.HttpClientWrapper.Post(GlobalConfiguration.Configuration.Settings.UrlEndPoint, httpContent);
		}

		internal virtual void Send(Track track)
		{
			var httpContent = track.GetBody();
			GlobalConfiguration.Configuration.HttpClientWrapper.Post(GlobalConfiguration.Configuration.Settings.UrlEndPoint, httpContent);
		}

	}
}
