using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankProjectUI.Startup))]
namespace BankProjectUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
