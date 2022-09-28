using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(JazzJune.Web.Api.Startup))]

namespace JazzJune.Web.Api;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        string sqlConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(sqlConnectionString));
    }
}
