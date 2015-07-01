using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppln.Startup))]
namespace WebAppln
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
