namespace ORMDemo
{
    using System;

    using FluentNHibernate;
    using FluentNHibernate.Conventions;

    public class MyForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            var refName = property == null ? type.Name : property.Name;
            return $"ID_{refName}s";
        }
    }
}
