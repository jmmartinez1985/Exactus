using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JP.Exactus.Web.Startup))]
namespace JP.Exactus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
