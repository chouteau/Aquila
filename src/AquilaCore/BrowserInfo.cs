using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class BrowserInfo
	{
		public string Ip { get; set; }
		public string UserAgent { get; set; }
		public string Accept { get; set; }
		public string AcceptEncoding { get; set; }
		public string AcceptLanguage { get; set; }
		public string AcceptCharset { get; set; }
		public string UpgradeInsecureRequest { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var pi in this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                result.Append(pi.GetValue(this));
            }

            return result.ToString();
        }

        public string GetSHA256()
        {
            var input = this.ToString();
            var crypto = new System.Security.Cryptography.SHA256Managed();
            var buffer = System.Text.Encoding.UTF8.GetBytes(input);
            var hash = crypto.ComputeHash(buffer);
            var result = string.Join(string.Empty, from b in hash select b.ToString("x2"));
            return result;
        }

    }
}
