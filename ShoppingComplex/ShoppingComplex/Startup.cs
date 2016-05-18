using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingComplex.Startup))]
namespace ShoppingComplex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
