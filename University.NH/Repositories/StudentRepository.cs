namespace University.NH.Repositories
{
    using NHibernate;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using University.Domain;

    public class StudentRepository : IStudentRepository
    {
        private readonly ISession session;

        public StudentRepository(ISessionFactory sessionFactory)
        {
            var factory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));

            this.session = factory.OpenSession();
        }

        public IQueryable<Student> GetAll()
        {
            return this.session.Query<Student>();
        }

        public Student Get(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public bool TryGet(int id, out Student student)
        {
            student = this.Get(id);
            return student != null;
        }

        public IQueryable<Student> Filter(Expression<Func<Student, bool>> filter)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return this.GetAll().Where(filter);
        }
    }
}
