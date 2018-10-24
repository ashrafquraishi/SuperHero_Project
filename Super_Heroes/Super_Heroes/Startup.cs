using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Super_Heroes.Startup))]
namespace Super_Heroes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
