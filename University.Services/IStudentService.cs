using System.Collections.Generic;
using University.Domain;

namespace University.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        List<Teacher> GetTeachersByStudentId(int id);
    }
}
