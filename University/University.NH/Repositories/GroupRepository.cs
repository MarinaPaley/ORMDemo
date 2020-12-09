namespace University.NH.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using NHibernate;
    using University.Domain;

    public class GroupRepository : IGroupRepository
    {
        private readonly ISession session;

        public GroupRepository(ISession session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc cref="IGroupRepository"/>
        public Group Get(int id)
        {
            return this.GetAll().SingleOrDefault(g => g.Id == id);
        }

        public bool TryGet(int id, out Group group)
        {
            return (group = this.Get(id)) != null;
        }

        public IQueryable<Group> GetAll()
        {
            return this.session.Query<Group>();
        }

        public IQueryable<Group> Filter(Expression<Func<Group, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return this.GetAll().Where(filter);
        }

        public void Create(Group group)
        {
            throw new NotImplementedException();
        }

        public void Update(Group group)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
