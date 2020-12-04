namespace University.Services
{
    using System.Linq;
    using University.Domain;

    public interface ITeacherService
    {
        IQueryable<Teacher> GetAll();

        IQueryable<Teacher> GetTeachersByGroupId(int groupId);
    }
}
