using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aquila
{
	public static class MiddlewareExtensions
	{
		public static IServiceCollection AddAquila(this IServiceCollection services, Action<Settings> configuration = null)
		{
			var settings = new Settings();
			configuration?.Invoke(settings);
			services.AddSingleton(settings);

			services.AddTransient<TrackSender>();

			services.AddTransient<PageTrack>();
			services.AddTransient<EnhancedTransactionTrack>();
			services.AddTransient<DefaultTrack>();
			services.AddTransient<TransactionTrack>();

			services.AddTransient<IClientIdGenerator, ClientIdCookieGenerator>();
			services.AddTransient<IClientIdGenerator, BrowserIdClientIdGenerator>();
			services.AddTransient<ClientIdFactory>();

			services.AddMemoryCache();

			var version = typeof(MiddlewareExtensions).Assembly.GetName().Version.ToString();
			services.AddHttpClient("GA")
				.ConfigureHttpClient(configure =>
				{
					configure.DefaultRequestHeaders.UserAgent.ParseAdd($"AquilaCore/{version} (+https://github.com/chouteau/Aquila)");
					configure.Timeout = TimeSpan.FromSeconds(5);
				})
				.ConfigurePrimaryHttpMessageHandler(() =>
				{
					var handler = new HttpClientHandler()
					{
						AllowAutoRedirect = false,
						UseCookies = false
					};
					return handler;
				});

			return services;
		}
	}
}
