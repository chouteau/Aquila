using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Aquila
{
	public abstract class TrackBuilder
	{
		internal Track m_Track;

		public TrackBuilder()
		{

		}

		public TrackBuilder(
			Settings settings,
			ILogger logger,
			TrackSender trackSender,
			ClientIdFactory clientIdFactory)
		{
			this.Settings = settings;
			this.Logger = logger;
			this.TrackSender = trackSender;
			this.ClientIdFactory = clientIdFactory;

			try
			{
				m_Track = CreateTrack();
				Campaign = new Campaign(m_Track);
			}
			catch (Exception ex)
			{
				logger.LogError(ex, ex.Message);
			}
		}

		protected Settings Settings { get; }
		protected ILogger Logger { get; }
		protected TrackSender TrackSender { get; }
		protected ClientIdFactory ClientIdFactory { get; }

		protected abstract string HitType { get; }

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

		public virtual string Referer
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
			m_Track.HitType = this.HitType;
			await TrackSender.SendAsync(m_Track);
		}

		public virtual async Task SendAsync(HttpContext httpContext)
		{
			BindTrackFromHttpContext(m_Track, httpContext);
			await SendAsync();
		}

		private Track CreateTrack()
		{
			var track = new Track();
			track.ProtocolVersion = "1";
			track.TrackingId = track.TrackingId ?? Settings.TrackingId;
			track.CurrencyCode = track.CurrencyCode ?? Settings.CurrencyCode;
			return track;
		}

		private void BindTrackFromHttpContext(Track track, HttpContext httpContext)
		{

			var clientInfo = ClientIdFactory.GetClientInfo(httpContext);
			track.ClientId = clientInfo.Id;
			if (clientInfo.IsNewSession)
			{
				track.SessionControl = "start";
			}

			track.UserId = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name : null;

			// Session
			track.IPOverride = httpContext.GetUserHostAddress();
			track.UserAgentOverride = httpContext.GetUserAgent();

			// Traffic Sources
			track.DocumentReferer = httpContext.Request.GetTypedHeaders()?.Referer?.AbsoluteUri;
			track.CampaignName = httpContext.GetParameter(Settings.CampaignParameterName);
			track.CampaignSource = httpContext.GetParameter(Settings.CampaignSourceParameterName);
			track.CampaignMedium = httpContext.GetParameter(Settings.CampaignMediumParameterName);
			track.CampaignKeyword = httpContext.GetParameter(Settings.CampaignKeywordParameterName);
			track.CampaignContent = httpContext.GetParameter(Settings.CampaignContentParameterName);
			track.CampaignId = httpContext.GetParameter(Settings.CampaignIdParameterName);
			track.GoogleAdwordsId = httpContext.GetParameter(Settings.GoogleAdwordsParameterName);
			track.GoogleDisplayAdsId = httpContext.GetParameter(Settings.GoogleDisplayAdsIdParamterName);

			// System Info
			track.UserLanguage = httpContext.GetDefaultUserLanguage();

			// Content Information
			track.DocumentLocationUrl = $"{httpContext.GetAbsoluteUri()}";
			track.DocumentHostName = httpContext.Request.Host.Value;
			track.DocumentPath = httpContext.Request.Path;
		}

	}
}
