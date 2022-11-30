using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Luxor.Startup))]
namespace Luxor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
