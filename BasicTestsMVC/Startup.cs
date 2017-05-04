using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasicTestsMVC.Startup))]
namespace BasicTestsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
