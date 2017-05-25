using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiCED.Startup))]
namespace SiCED
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
