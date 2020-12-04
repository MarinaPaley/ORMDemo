namespace ORMDemo
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NHibernate;

    using University.Domain;
    using University.NH.Repositories;
    using University.Services;

    /// <summary>
    /// Демонстрационное приложение.
    /// </summary>
    internal class App
    {
        private readonly IStudentService studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="studentService"> </param>
        public App(IStudentService studentService)
        {
            this.studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        /// <summary>
        /// Метод запуска приложения.
        /// </summary>
        /// <returns> Успешно завершённая задача. </returns>
        public async Task Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var studentId = 1;

            var teachers = this.studentService.GetTeachersByStudentId(studentId);
            foreach (var item in teachers)
            {
                Console.WriteLine(item);
            }

            await Task.CompletedTask;
        }
    }
}
