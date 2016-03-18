using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment5part1.Startup))]
namespace Assignment5part1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
