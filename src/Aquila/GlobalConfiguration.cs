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
		private static bool m_IsMapperInitialized;
		private static Lazy<AquilaConfiguration> m_Configuration
				= new Lazy<AquilaConfiguration>(() =>
					{
						var config = System.Configuration.ConfigurationManager.GetSection("aquila") as NameValueCollection;
						var settings = new Settings();
						settings.BindFromConfiguration(config);

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

		internal static void ConfigureMapping()
		{
			if (!Configuration.Settings.StartSelfAutoMapper)
			{
				return;
			}

			if (m_IsMapperInitialized)
			{
				return;
			}

			AutoMapper.Mapper.Initialize(cfg =>
					cfg.AddProfile(new AutoMapperProfile())
			);
			m_IsMapperInitialized = true;
		}

	}
}
