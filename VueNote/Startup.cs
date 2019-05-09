using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VueNote.Startup))]
namespace VueNote
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
