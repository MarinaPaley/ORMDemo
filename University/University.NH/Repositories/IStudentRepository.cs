using System;
using System.Linq;
using System.Linq.Expressions;
using University.Domain;

namespace University.NH.Repositories
{
    public interface IStudentRepository
    {
        IQueryable<Student> Filter(Expression<Func<Student, bool>> filter);
        Student Get(int id);
        IQueryable<Student> GetAll();
        bool TryGet(int id, out Student student);
    }
}