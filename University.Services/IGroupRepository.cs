namespace University.Services
{
    using System.Linq;
    using University.Domain;

    public interface IGroupRepository
    {
        IQueryable<Group> GetAll();
    }
}
