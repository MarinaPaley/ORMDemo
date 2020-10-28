namespace ORMDemo
{
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        internal static void Main(string[] args) => MainAsync(args).Wait();

        private static async Task MainAsync(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddConfigurationFromFile("appsettings.json");
            serviceCollection.AddNHibernateConfiguration("relative");
            serviceCollection.AddTransient<App>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            await serviceProvider.GetService<App>().Run();
        }
    }
}
