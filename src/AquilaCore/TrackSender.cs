using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class TrackSender
	{
		public TrackSender(Settings settings,
			ILogger<TrackSender> logger,
			IHttpClientFactory httpClientFactory)
		{
			this.Settings = settings;
			this.Logger = logger;
			this.HttpClientFactory = httpClientFactory;
		}

		protected Settings Settings { get; }
		protected ILogger<TrackSender> Logger { get; }
		protected IHttpClientFactory HttpClientFactory { get; }

		internal virtual async Task SendAsync(Track track)
		{
			if (track.TrackingId == null)
			{
				throw new KeyNotFoundException("TrackingId not configured");
			}

			var httpClient = HttpClientFactory.CreateClient("GA");

			var httpContent = GetBodyContent(track);
			var response = await httpClient.PostAsync(Settings.UrlEndPoint, httpContent);
			try
			{
				response.EnsureSuccessStatusCode();
			}
			catch (Exception ex)
			{
				Logger.LogError(ex, ex.Message);
			}
			await response.Content.ReadAsStringAsync();
		}

		private HttpContent GetBodyContent(Track track)
		{
			var parameters = GetTrackParameters(track);
			var kv = (from p in parameters
					  select string.Format("{0}={1}", p.Key, p.Value)).ToList();

			foreach (var product in track.ProductList)
			{
				var index = track.ProductList.IndexOf(product) + 1;
				var kvp = (from p in GetTrackParameters(product)
						   let key = p.Key.Replace("<index>", index.ToString())
						   select string.Format("{0}={1}", key, p.Value));

				kv.AddRange(kvp);
			}

			var query = string.Join("&", kv);

			var httpContent = new StringContent(query);
			return httpContent;
		}

		private Dictionary<string, string> GetTrackParameters(object track)
		{
			var result = new Dictionary<string, string>();
			var ci = new System.Globalization.CultureInfo("en-US");
			ci.NumberFormat.CurrencyDecimalSeparator = ".";
			ci.NumberFormat.NumberDecimalSeparator = ".";
			ci.NumberFormat.PercentDecimalSeparator = ".";

			foreach (var pi in track.GetType().GetProperties())
			{
				var value = pi.GetValue(track, null);
				if (value == null)
				{
					continue;
				}

				var attr = pi.GetCustomAttributes(false).SingleOrDefault(i => i is ParameterAttribute);
				if (attr == null)
				{
					continue;
				}

				var gparamter = attr as ParameterAttribute;
				var parameterName = gparamter.ParameterName;
				var parameterValue = System.Uri.EscapeDataString(Convert.ToString(value, ci));

				if (gparamter.MaxLength > 0)
				{
					parameterValue = parameterValue.Substring(0, Math.Min(parameterValue.Length, gparamter.MaxLength));
				}

				result.Add(parameterName, parameterValue);
			}
			return result;
		}



	}
}
