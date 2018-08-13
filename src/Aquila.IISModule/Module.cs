using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(Aquila.Module), "Start")]

namespace Aquila
{
    public class Module : IHttpModule
    {
        public void Dispose()
        {
        }

        public static void Start()
        {
            Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(Module));
        }

        public void Init(HttpApplication app)
        {
            if (GlobalConfiguration.Configuration.Settings.AutoStart)
            {
                app.EndRequest += new EventHandler(context_EndRequest);
            }
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;

            var pageExtension = System.IO.Path.GetExtension(app.Context.Request.Path);
            if (GlobalConfiguration.Configuration.BanishedExtensions.Contains(pageExtension))
            {
                return;
            }

            var ctxbase = new System.Web.HttpContextWrapper(app.Context);
            var builder = new PageTrack(ctxbase);
            Task.Run(async () =>
                {
                    await builder.SendAsync();
                }
            );
        }
    }
}