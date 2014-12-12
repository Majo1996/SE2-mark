using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SE2_ontwikkelopdracht.Startup))]
namespace SE2_ontwikkelopdracht
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
