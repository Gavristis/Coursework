using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Coursework.Web.Startup))]
namespace Coursework.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
