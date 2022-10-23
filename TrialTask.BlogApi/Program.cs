using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.WebApi;
using TrialTask.Util.DI;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System.Web.Http;

internal class Program
{
    private static void Main(string[] args)
    {
       
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        // Call ConfigureContainer on the Host sub property 
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {

            var dm = DependencyManager.Instance;
            ////var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            dm.AddContainerBuilder(containerBuilder);
            TrialTask.BusinessLogic.AssemblyInitializer.Init(dm);
            //containerBuilder.Populate(builder.Services);

        });
        //var config = GlobalConfiguration.Configuration;
        //config.DependencyResolver = new AutofacWebApiDependencyResolver(dm.CompleteRegistration());

        var app = builder.Build();
 
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}