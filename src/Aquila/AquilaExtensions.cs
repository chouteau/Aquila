using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	internal static class AquilaExtensions
	{
		internal static Dictionary<string, string> GetParameters(this Track track)
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

		internal static HttpContent GetBody(this Track track)
		{
			var parameters = track.GetParameters();
			var kv = (from p in parameters
					  select string.Format("{0}={1}", p.Key, p.Value));
			var query = string.Join("&", kv);

			var httpContent = new StringContent(query);
			return httpContent;
		}

	}
}
