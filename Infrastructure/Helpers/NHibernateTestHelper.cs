using System.Reflection;

namespace Infrastructure.Helpers
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class NHibernateTestHelper
    {
        private static Configuration savedConfiguration = null;

        public static ISession GetSession(bool showSql, params Type[] mappingTypes)
        {
            //FluentConfiguration fluentConfiguration = CreateConfiguration(mappingTypes, showSql);
            //return NHibernateTestHelper.CreateSession(fluentConfiguration);

            return CreateConfiguration(showSql, Register(mappingTypes)).CreateSession();
        }

        public static ISession GetSession(bool showSql, params Assembly[] assemblies)
        {
            //FluentConfiguration fluentConfiguration = CreateConfiguration(mappingTypes, showSql);
            //return NHibernateTestHelper.CreateSession(fluentConfiguration);

            return CreateConfiguration(showSql, Register(assemblies)).CreateSession();
        }

        public static ISession GetSession(bool showSql, Action<FluentMappingsContainer> registrar)
        {
            //FluentConfiguration fluentConfiguration = CreateConfiguration(mappingTypes, showSql);
            //return NHibernateTestHelper.CreateSession(fluentConfiguration);

            return CreateConfiguration(showSql, Register(registrar)).CreateSession();
        }

        private static Action<FluentConfiguration> Register(IEnumerable<Type> types)
        {
            return cfg => cfg.Mappings(x => x.FluentMappings.AddRange(types));
        }

        private static Action<FluentConfiguration> Register(IEnumerable<Assembly> assemblies)
        {
            return cfg => cfg.Mappings(x => x.FluentMappings.AddFromAssemblyRange(assemblies));
        }

        private static Action<FluentConfiguration> Register(Action<FluentMappingsContainer> registrar)
        {
            return cfg => cfg.Mappings(x => registrar?.Invoke(x.FluentMappings));
        }

        private static FluentConfiguration CreateConfiguration(bool showSql, Action<FluentConfiguration> registerAction)
        {
            var sqliteConfiguration = SQLiteConfiguration.Standard.InMemory();
            if (showSql)
            {
                sqliteConfiguration = sqliteConfiguration.ShowSql().FormatSql();
            }

            var cfg = Fluently.Configure().Database(sqliteConfiguration);
            registerAction?.Invoke(cfg);
            return cfg.ExposeConfiguration(configuration => savedConfiguration = configuration);

            //return Fluently.Configure()
            //    .Database(sqliteConfiguration)
            //    .Register(mappingTypes)
            //    .ExposeConfiguration(configuration => savedConfiguration = configuration);

            // var configuration = Fluently.Configure().Database(sqliteConfiguration);

            // y = f(x)(z) <=> f(x) -> g(arg1), g(z) -> y
            // Register(mappingTypes).Invoke(configuration);

            //return Fluently.Configure()
            //    .Database(sqliteConfiguration)
            //    .Mappings(m => m
            //        .FluentMappings.AddFromAssembly(assembly));

            //return configuration.ExposeConfiguration(cfg => savedConfiguration = cfg);
        }

        private static ISession CreateSession(this FluentConfiguration configuration)
        {
            var session = configuration.BuildSessionFactory().OpenSession();
            new SchemaExport(savedConfiguration ?? configuration.BuildConfiguration())
                .Execute(true, true, false, session.Connection, Console.Out);
            return session;
        }
    }

    internal static class FluentMappingsContainerExtensions
    {
        public static void AddRange(this FluentMappingsContainer container, IEnumerable<Type> types)
        {
            foreach (var type in types ?? Enumerable.Empty<Type>())
            {
                container?.Add(type);
            }
        }

        public static void AddFromAssemblyRange(this FluentMappingsContainer container, IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies ?? Enumerable.Empty<Assembly>())
            {
                container?.AddFromAssembly(assembly);
            }
        }
    }

    internal static class FluentConfigurationExtensions
    {
        public static FluentConfiguration RegisterMappingTypes(this FluentConfiguration cfg, Type[] mappingTypes)
        {
            return cfg.Mappings(x => x.FluentMappings.AddRange(mappingTypes));
        }
    }
}
