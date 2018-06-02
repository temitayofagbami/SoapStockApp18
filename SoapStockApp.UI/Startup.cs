using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoapStockApp.UI.Startup))]
namespace SoapStockApp.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
