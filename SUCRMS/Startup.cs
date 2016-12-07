using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SUCRMS.Startup))]
namespace SUCRMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
