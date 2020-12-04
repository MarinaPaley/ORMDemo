namespace University.Services
{
    using System.Linq;
    using University.Domain;

    public interface IGroupService
    {
        IQueryable<Group> GetAll();

        bool TryGet(int id, out Group group);
    }
}
