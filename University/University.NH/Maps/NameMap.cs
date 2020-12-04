namespace University.NH.Maps
{
    using FluentNHibernate.Mapping;

    using University.Domain;

    /// <summary>
    /// Правила отображения для <see cref="Name"/>.
    /// </summary>
    internal class NameMap : ComponentMap<Name>
    {
        public NameMap()
        {
            this.Map(x => x.LastName);
            this.Map(x => x.FirstName);
            this.Map(x => x.MiddleName);
        }
    }
}
