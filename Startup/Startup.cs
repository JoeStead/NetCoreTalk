using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

namespace netcoretalk.Startup
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x =>
           {
               x.UseNancy();
           });
        }
    }
}