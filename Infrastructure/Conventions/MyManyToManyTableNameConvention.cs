namespace Infrastructure.Conventions
{
    using System;

    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Inspections;

    internal class MyManyToManyTableNameConvention : ManyToManyTableNameConvention
    {
        protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection, IManyToManyCollectionInspector otherSide)
        {
            var tmp = $"{collection.ChildType.Name}_{otherSide.ChildType.Name}";
            Console.WriteLine(tmp);
            return tmp;
        }

        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            var tmp = $"{collection.ChildType.Name}_{collection.OtherSide.ChildType.Name}";
            return tmp;
        }
    }
}