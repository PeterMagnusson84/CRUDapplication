using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactApplication.Startup))]
namespace ContactApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
