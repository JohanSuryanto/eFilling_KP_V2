using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eFilling_KP_V2.Startup))]
namespace eFilling_KP_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
