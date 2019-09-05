using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Abantwana_DayCare.Startup))]
namespace Abantwana_DayCare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
