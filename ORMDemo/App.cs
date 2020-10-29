namespace ORMDemo
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NHibernate;

    using University.Domain;

    /// <summary>
    /// Демонстрационное приложение.
    /// </summary>
    internal class App
    {
        /// <summary>
        /// Фабрика сессий для работы с БД.
        /// </summary>
        private readonly ISessionFactory sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="sessionFactory"> Фабрика сессий для работы с БД. </param>
        public App(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

        /// <summary>
        /// Метод запуска приложения.
        /// </summary>
        /// <returns> Успешно завершённая задача. </returns>
        public async Task Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            using (var session = this.sessionFactory.OpenSession())
            {
                var students = session.Query<Student>().ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }

                var teachers = session.Query<Teacher>().ToList();
                foreach (var teacher in teachers)
                {
                    Console.WriteLine(teacher);
                }
            }

            await Task.CompletedTask;
        }
    }
}
