using System;
using System.Linq;
using System.Linq.Expressions;
using University.Domain;

namespace University.NH.Repositories
{
    public interface ITeacherRepository
    {
        IQueryable<Teacher> Filter(Expression<Func<Teacher, bool>> filter);

        IQueryable<Teacher> GetAll();

        bool TryGet(int id, out Teacher teacher);
    }
}
