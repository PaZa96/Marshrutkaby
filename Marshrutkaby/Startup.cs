using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marshrutkaby.Startup))]
namespace Marshrutkaby
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
