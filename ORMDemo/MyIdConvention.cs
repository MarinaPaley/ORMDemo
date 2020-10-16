namespace ORMDemo
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    class MyIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Assigned();
        }
    }
}
