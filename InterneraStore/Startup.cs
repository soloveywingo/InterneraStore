using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterneraStore.Startup))]
namespace InterneraStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
