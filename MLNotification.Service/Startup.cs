using Microsoft.Owin.Cors;
using Owin;

namespace MLNotification.Service
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
