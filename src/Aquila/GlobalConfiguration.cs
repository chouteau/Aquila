using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class GlobalConfiguration
	{
		private static Lazy<AquilaConfiguration> m_Configuration
				= new Lazy<AquilaConfiguration>(() =>
					{
						var config = System.Configuration.ConfigurationManager.GetSection("aquila") as NameValueCollection;
						var settings = new Settings();
						settings.BindFromConfiguration(config);

						ConfigureMapping();

						return new AquilaConfiguration()
						{
							Settings = settings,
							BanishedExtensions = settings.BanishedExtensions.Split(','),
							HttpClientWrapper = new HttpClientWrapper(),
							Logger = new DiagnosticsLogger()
						};
					}, true);

		public static AquilaConfiguration Configuration
		{
			get
			{
				return m_Configuration.Value;
			}
		}

		private static void ConfigureMapping()
		{
			AutoMapper.Mapper.Initialize(cfg =>
				cfg.CreateMap<System.Web.HttpContextBase, Track>()
				// User
					.ForMember(dest => dest.ClientId, opt => opt.MapFrom(source => (source.Request.Cookies[GlobalConfiguration.Configuration.Settings.CookieName] != null) ? source.Request.Cookies[GlobalConfiguration.Configuration.Settings.CookieName].Value : null))
					.ForMember(dest => dest.UserId, opt => opt.MapFrom(source => (source.User.Identity.IsAuthenticated) ? source.User.Identity.Name : null))
					// Session
					.ForMember(dest => dest.IPOverride, opt => opt.MapFrom(source => source.Request.UserHostAddress))
					.ForMember(dest => dest.UserAgentOverride, opt => opt.MapFrom(source => source.Request.UserAgent))
					// Traffic Sources
					.ForMember(dest => dest.DocumentReferer, opt => opt.MapFrom(source => (source.Request.UrlReferrer != null) ? source.Request.UrlReferrer.ToString() : null))
					.ForMember(dest => dest.CampaignName, opt => opt.MapFrom(source => source.Request.Url.GetParameter(GlobalConfiguration.Configuration.Settings.CampaignParameterName)))
					.ForMember(dest => dest.CampaignSource, opt => opt.MapFrom(source => source.Request.Url.GetParameter(GlobalConfiguration.Configuration.Settings.CampaignSourceParameterName)))
					.ForMember(dest => dest.CampaignMedium, opt => opt.MapFrom(source => source.Request.Url.GetParameter(GlobalConfiguration.Configuration.Settings.CampaignMediumParameterName)))
					.ForMember(dest => dest.CampaignKeyword, opt => opt.MapFrom(source => source.Request.Url.GetParameter(GlobalConfiguration.Configuration.Settings.CampaignKeywordParameterName)))
					.ForMember(dest => dest.CampaignContent, opt => opt.MapFrom(source => source.Request.Url.GetParameter(GlobalConfiguration.Configuration.Settings.CampaignContentParameterName)))
					.ForMember(dest => dest.CampaignId, opt => opt.MapFrom(source => source.Request.Url.GetParameter(GlobalConfiguration.Configuration.Settings.CampaignIdParameterName)))
					.ForMember(dest => dest.GoogleAdwordsId, opt => opt.MapFrom(source => source.Request.Url.GetParameter(GlobalConfiguration.Configuration.Settings.GoogleAdwordsParameterName)))
					.ForMember(dest => dest.GoogleDisplayAdsId, opt => opt.MapFrom(source => source.Request.Url.GetParameter(GlobalConfiguration.Configuration.Settings.GoogleDisplayAdsIdParamterName)))
					// System Info
					.ForMember(dest => dest.UserLanguage, opt => opt.MapFrom(source => source.Request.GetDefaultUserLanguage()))
					// Content Information
					.ForMember(dest => dest.DocumentLocationUrl, opt => opt.MapFrom(source => source.Request.Url.AbsoluteUri))
					.ForMember(dest => dest.DocumentHostName, opt => opt.MapFrom(source => source.Request.Url.Host))
					.ForMember(dest => dest.DocumentPath, opt => opt.MapFrom(source => source.Request.Path))

			// Construction
			// .ConstructUsing((global::System.Func<AutoMapper.ResolutionContext, Track>)(x => Track.Create()));
			);
		}

	}
}
