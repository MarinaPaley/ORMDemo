using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using Infrastructure.Helpers;
using NHibernate;
using University.NH;
using University.NH.Repositories;
using University.Services;

namespace University.WebServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            AddConfigurationFromFile(services,"appsettings.json");
            AddNHibernateConfiguration(services, "relative");

            services.AddTransient(sp => sp.GetService<ISessionFactory>().OpenSession());

            services.AddSingleton<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ITeacherService, TeacherService>();

            services.AddSingleton<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        internal static IServiceCollection AddConfigurationFromFile(IServiceCollection serviceCollection, string filename)
        {
            var basePath = Directory.GetParent(AppContext.BaseDirectory).FullName;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(filename, optional: false, reloadOnChange: true)
                .Build();

            return serviceCollection.AddSingleton(configuration);
        }

        internal static IServiceCollection AddNHibernateConfiguration(IServiceCollection serviceCollection, string connectionStringKey)
        {
            return serviceCollection.AddSingleton(serviceProvider => GetSessionFactory(serviceProvider, connectionStringKey));
        }

        private static ISessionFactory GetSessionFactory(IServiceProvider serviceProvider, string connectionStringKey)
        {
            var basePath = Directory.GetParent(AppContext.BaseDirectory).FullName;

            var configuration = serviceProvider.GetService<IConfigurationRoot>();

            var dataSourceLocation = Path.GetFullPath(configuration.GetConnectionString(connectionStringKey), basePath);

            NHibernateConfigurator.DataSourceLocation = dataSourceLocation;

            NHibernateConfigurator.GetConfiguration(UniversityNHibernateConfigurator.GetAssembly());

            return NHibernateConfigurator.GetSessionFactory();
        }
    }
}
