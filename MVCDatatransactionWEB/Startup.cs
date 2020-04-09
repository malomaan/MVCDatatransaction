using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDatatransactionWEB.Startup))]
namespace MVCDatatransactionWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
