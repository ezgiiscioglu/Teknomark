using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SakaryaBufe.Startup))]
namespace SakaryaBufe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
