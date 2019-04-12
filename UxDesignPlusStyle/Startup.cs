using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UxDesignPlusStyle.Startup))]
namespace UxDesignPlusStyle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
