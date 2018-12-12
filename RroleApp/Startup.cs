using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RroleApp.Startup))]
namespace RroleApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
