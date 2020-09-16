using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ForumProject.Areas.Identity.IdentityHostingStartup))]
namespace ForumProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}