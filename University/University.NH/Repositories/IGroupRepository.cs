namespace University.NH.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using University.Domain;

    public interface IGroupRepository
    {
        /// <summary>
        /// Получение группы по её идентификатору.
        /// </summary>
        /// <param name="id"> Идентификатор искомой группы. </param>
        /// <returns> Группа или <see langword="null" /></returns>
        Group Get(int id);

        bool TryGet(int id, out Group group);

        IQueryable<Group> GetAll();

        IQueryable<Group> Filter(Expression<Func<Group, bool>> filter);

        void Create(Group group);

        void Update(Group group);

        void Delete(Group group);
    }
}
