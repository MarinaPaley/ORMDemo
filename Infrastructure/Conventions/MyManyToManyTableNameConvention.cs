namespace Infrastructure.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Inspections;

    /// <summary>
    /// Собственная конвенция по наименованию промежуточной сущности в связи многие-ко-многим.
    /// </summary>
    internal class MyManyToManyTableNameConvention : ManyToManyTableNameConvention
    {
        /// <inheritdoc />
        protected override string GetBiDirectionalTableName(
            IManyToManyCollectionInspector collection,
            IManyToManyCollectionInspector otherSide)
        {
            return $"{collection.ChildType.Name}_{otherSide.ChildType.Name}";
        }

        /// <inheritdoc />
        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return $"{collection.ChildType.Name}_{collection.OtherSide.ChildType.Name}";
        }
    }
}
