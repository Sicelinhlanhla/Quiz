using Abantwana_DayCare.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Abantwana_DayCare.Startup))]
namespace Abantwana_DayCare
{
    public partial class Startup
    {
		ApplicationDbContext db = new ApplicationDbContext();
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
			CreateRole();
			CreateUser();
		}
	}
}
