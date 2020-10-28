namespace Infrastructure.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    /// <summary>
    /// Собственная настройка договорённости (конвенции) о формате первичных ключей.
    /// </summary>
    internal class MyIdConvention : IIdConvention
    {
        /// <summary>
        /// Метод, применяющий правила порождения значения ключа на стороне приложения.
        /// </summary>
        /// <param name="instance"> Объект типа. </param>
        public void Apply(IIdentityInstance instance) => instance.GeneratedBy.Assigned();
    }
}
