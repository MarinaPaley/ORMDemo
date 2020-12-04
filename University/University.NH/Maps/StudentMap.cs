namespace University.NH.Maps
{
    using FluentNHibernate.Mapping;

    using University.Domain;

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            this.Table("Students");

            this.Id(x => x.Id);
            this.Map(x => x.Name, "Name");
            this.References(x => x.Group);
        }
    }
}
