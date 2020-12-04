namespace University.Services
{
    using System;
    using System.Linq;
    using University.Domain;

    public class GroupService : IGroupService
    {
        private readonly IGroupRepository repository;

        public GroupService(IGroupRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IQueryable<Group> GetAll()
        {
            return this.repository.GetAll();
        }

        public bool TryGet(int id, out Group group)
        {
            group = this.GetAll().SingleOrDefault(g => g.Id == id);
            return group != null;
        }
    }
}
