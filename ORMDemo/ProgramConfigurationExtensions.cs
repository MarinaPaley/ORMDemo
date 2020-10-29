namespace ORMDemo
{
    using System;
    using System.IO;

    using Infrastructure.Helpers;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using NHibernate;

    using University.NH;

    internal static class ProgramConfigurationExtensions
    {
        internal static IServiceCollection AddConfigurationFromFile(this IServiceCollection serviceCollection, string filename)
        {
            var basePath = Directory.GetParent(AppContext.BaseDirectory).FullName;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(filename, optional: false, reloadOnChange: true)
                .Build();

            return serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
        }

        internal static IServiceCollection AddNHibernateConfiguration(this IServiceCollection serviceCollection, string connectionStringKey)
        {
            return serviceCollection.AddSingleton<ISessionFactory>(p => GetSessionFactory(p, connectionStringKey));
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