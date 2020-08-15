using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealtAirTechExam.Startup))]
namespace RealtAirTechExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
