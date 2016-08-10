using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eSocial.Startup))]
namespace eSocial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
