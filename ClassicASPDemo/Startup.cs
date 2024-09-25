using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassicASPDemo.Startup))]
namespace ClassicASPDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
