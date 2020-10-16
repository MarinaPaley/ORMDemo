namespace ORMDemo
{
    using System;
    using System.Linq;
    using System.Text;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;

    class Program
    {
        /// <summary>
        /// The data source location.
        /// </summary>
        private const string dataSourceLocation = @"C:\Users\Marina\source\repos\ORMDemo\DataSources\demo.db";

        private static string GetConnectionString()
        {
            return $"Data Source={dataSourceLocation};Version=3;UTF8Encoding=True;";
        }

        private static ISessionFactory GetSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .ConnectionString(GetConnectionString())
                        //.UsingFile(dataSourceLocation)
                        //.ShowSql()
                        //.FormatSql()
                )
                .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<Program>()
                    .Conventions.Add<MyIdConvention>()
                    .Conventions.Add<MyForeignKeyConvention>())
                
                .BuildSessionFactory();
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var factory = GetSessionFactory();

            using (var session = factory.OpenSession())
            {
                var students = session.Query<Student>().ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
