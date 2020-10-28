namespace ORMDemo
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NHibernate;

    using University.Domain;

    internal class App
    {
        private readonly ISessionFactory sessionFactory;

        public App(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

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
