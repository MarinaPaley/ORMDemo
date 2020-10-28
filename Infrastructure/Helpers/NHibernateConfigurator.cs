namespace Infrastructure.Helpers
{
    using System.Reflection;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;

    /// <summary>
    /// Класс-помощник для настройки NHibernate.
    /// </summary>
    public static class NHibernateConfigurator
    {
        /// <summary>
        /// The data source location.
        /// </summary>
        public static string DataSourceLocation = @"C:\Users\Marina\source\repos\ORMDemo\DataSources\demo.db";

        private static string GetConnectionString() => $"Data Source={DataSourceLocation};Version=3;UTF8Encoding=True;";

        private static FluentConfiguration config;

        public static FluentConfiguration GetConfiguration(Assembly assembly, bool showSql = false)
        {
            var configuration = SQLiteConfiguration.Standard.ConnectionString(GetConnectionString());
            if (showSql)
            {
                configuration = configuration.ShowSql().FormatSql();
            }

            return config = Fluently.Configure()
                .Database(configuration)
                .Mappings(m => m
                    .FluentMappings.AddFromAssembly(assembly)
                    .Conventions.AddAssembly(Assembly.GetExecutingAssembly()));
                    //.Conventions.Add<MyIdConvention>()
                    //.Conventions.Add<MyForeignKeyConvention>()
                    //.Conventions.Add<MyManyToManyTableNameConvention>());
        }

        public static ISessionFactory GetSessionFactory() => config?.BuildSessionFactory();
    }
}
