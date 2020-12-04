namespace University.Services
{
    using System;
    using System.Linq;
    using NHibernate;
    using University.Domain;

    public class GroupRepository : IGroupRepository
    {
        private readonly ISession session;

        public GroupRepository(ISession session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public IQueryable<Group> GetAll()
        {
            return this.session.Query<Group>();
        }
    }
}
