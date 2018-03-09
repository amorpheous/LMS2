using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMS2.Startup))]
namespace LMS2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
