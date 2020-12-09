namespace University.NH.Maps
{
    using FluentNHibernate.Mapping;

    using University.Domain;

    /// <summary>
    /// Правила отображения для <see cref="Teacher"/>.
    /// </summary>
    internal class TeacherMap : ClassMap<Teacher>
    {
        public TeacherMap()
        {
            this.Table("Teachers");

            this.Id(x => x.Id).GeneratedBy.Increment(); //.HiLo("Teachers", "ID", "10");

            this.Component(x => x.Name);

            this.HasManyToMany(x => x.Groups);
            //// Конвенция по умолчанию обязывает третьей сущности / таблице иметь имя "GroupsToTeachers"
            //// Это требование может не совпадать с требованиями предъявляемыми к БД, можно использовать:
            //// .Table("Teacher_Group")
        }
    }
}
