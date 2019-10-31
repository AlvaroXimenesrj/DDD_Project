using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Loja.ProjetoDDD.UI.Sistema.Startup))]
namespace Loja.ProjetoDDD.UI.Sistema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
