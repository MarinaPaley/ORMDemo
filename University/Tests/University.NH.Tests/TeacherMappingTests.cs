namespace University.NH.Tests
{
    using FluentNHibernate.Testing;
    using Infrastructure.Helpers;
    using NHibernate;
    using NUnit.Framework;
    using University.Domain;
    using University.NH.Maps;


    public class TeacherMappingTests
    {
        private ISession session;

        [SetUp]
        public void Setup()
        {
            this.session = NHibernateTestHelper.GetSession(
                true,
                m => m.Add<TeacherMap>().Add<NameMap>().Add<GroupMap>().Add<StudentMap>());
        }

        [Test]
        public void TeacherMapping_NoNullFields_Success()
        {
            // arrange
            var name = new Name("Иван", "Иванов", "Иванович");

            // act & assert
            new PersistenceSpecification<Teacher>(this.session)
                .CheckProperty(x => x.Name, name)
                .VerifyTheMappings();
        }
    }
}
