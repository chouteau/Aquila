using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.DependencyInjection;

using Aquila;

namespace WinAquila
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var services = new ServiceCollection();

			services.AddLogging();
			services.AddAquila();
			services.AddScoped<MainForm>();

			var serviceProvider = services.BuildServiceProvider();

			var mainForm = serviceProvider.GetRequiredService<MainForm>();

			Application.Run(mainForm);
		}
	}
}
