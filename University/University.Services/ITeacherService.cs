namespace University.Services
{
    using System.Linq;
    using University.Domain;

    public interface ITeacherService
    {
        IQueryable<Teacher> GetAll();

        IQueryable<Teacher> GetTeachersByGroupId(int groupId);

        Teacher Create(string lastName, string firstName, string middleName);

        void Delete(int id);
    }
}
