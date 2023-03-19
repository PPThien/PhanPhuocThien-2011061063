using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhanPhuocThien_2011061063.Startup))]
namespace PhanPhuocThien_2011061063
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
