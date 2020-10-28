namespace University.NH
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Класс-помощник, обеспечивающий настройку для конкретной сборки.
    /// </summary>
    public class UniversityNHibernateConfigurator
    {
        /// <summary>
        /// Метод получения сборки.
        /// </summary>
        /// <returns> Исполняемая сборка. </returns>
        [Obsolete("Стоит переписать на расширение с учётом регистрации правил отображения и конвенций.")]
        public static Assembly GetAssembly() => Assembly.GetExecutingAssembly();
    }
}
