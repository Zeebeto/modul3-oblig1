using NUnit.Framework;
using Oblig1;

namespace Oblig1Test
{
    public class PersonTest
    {
        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.getDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.getDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void TestSomeFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                BirthYear = 2077,
                Father = new Person() { Id = 23, DeathYear = 2090 },
                Mother = new Person() { FirstName = "Lise" },
            };

            var actualDescription = p.getDescription();
            var expectedDescription = "Ola (Id=17) Født: 2077 Far: (Id=23) Mor: Lise";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}