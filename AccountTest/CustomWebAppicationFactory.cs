using HotChocolate;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest
{
    public class CustomWebAppicationFactory<TProgram>:WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(x =>
            {
                x.AddSingleton(cg => new RequestExecutorProxy(cg.GetRequiredService<IRequestExecutorResolver>(), Schema.DefaultName));

               
            });

            base.ConfigureWebHost(builder);
        }
    }
}
