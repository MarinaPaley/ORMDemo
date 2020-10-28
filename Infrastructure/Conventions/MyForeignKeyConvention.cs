namespace Infrastructure.Conventions
{
    using System;

    using FluentNHibernate;
    using FluentNHibernate.Conventions;

    /// <summary>
    /// Собственная настройка договорённости (конвенции) о формате вторичных (внешних) ключей.
    /// </summary>
    internal class MyForeignKeyConvention : ForeignKeyConvention
    {
        /// <summary>
        /// Метод, получающий имя вторичного (внешнего) ключа по имения свойства или имени типа свойства.
        /// </summary>
        /// <param name="property"> Свойство. </param>
        /// <param name="type"> Тип свойства. </param>
        /// <returns> Имя вторичного (внешнего) ключа. </returns>
        protected override string GetKeyName(Member property, Type type) => $"ID_{property?.Name ?? type.Name}s";
    }
}
