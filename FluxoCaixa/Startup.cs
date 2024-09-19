using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FluxoCaixa.Startup))]
namespace FluxoCaixa
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
