namespace University.Services
{
    using System;
    using System.Linq;
    using University.Domain;
    using University.NH.Repositories;

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

        public Group Get(int id)
        {
            return this.repository.Get(id);
        }

        public bool TryGet(int id, out Group group)
        {
            return this.repository.TryGet(id, out group);
        }
    }
}
