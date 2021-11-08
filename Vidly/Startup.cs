using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Vidly.Startup))]

namespace Vidly
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }
  }
}
