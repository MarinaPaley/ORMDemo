namespace ORMDemo
{
    using FluentNHibernate.Mapping;

    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            this.Table("Groups");

            this.Id(x => x.Id);

            this.Map(x => x.Name, "[Group]");
            this.HasMany(x => x.Students);
        }
    }
}
