using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(allpax_sale_miner_3.Startup))]
namespace allpax_sale_miner_3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
