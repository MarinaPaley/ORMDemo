namespace University.Services
{
    using System.Linq;
    using University.Domain;

    public interface ITeacherService
    {
        bool TryGet(int id, out Teacher teacher);

        IQueryable<Teacher> GetAll();

        IQueryable<Teacher> GetTeachersByGroupId(int groupId);

        Teacher Create(string lastName, string firstName, string middleName);

        void Delete(int id);
    }
}
