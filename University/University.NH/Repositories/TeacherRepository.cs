using NHibernate;
using System;
using System.Linq;
using System.Linq.Expressions;
using University.Domain;

namespace University.NH.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ISessionFactory sessionFactory;

        private readonly ISession session;

        public TeacherRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));

            this.session = this.sessionFactory.OpenSession();
        }

        public IQueryable<Teacher> GetAll()
        {
            return this.session.Query<Teacher>();
        }

        public bool TryGet(int id, out Teacher teacher)
        {
            teacher = this.GetAll().SingleOrDefault(t => t.Id == id);
            return teacher != null;
        }

        public Teacher Create(Teacher teacher)
        {
            var id = (int)this.session.Save(teacher);
            this.session.Flush();
            return teacher;
        }

        public void Delete(int id)
        {
            if (!this.TryGet(id, out var teacher))
            {
                return;
            }

            this.session.Delete(teacher);
            this.session.Flush();
        }

        public IQueryable<Teacher> Filter(Expression<Func<Teacher, bool>> filter)
        {
            return this.GetAll().Where(filter);
        }
    }
}
