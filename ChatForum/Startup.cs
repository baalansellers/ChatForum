using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatForum.Startup))]
namespace ChatForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
