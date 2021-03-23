using NUnit.Framework;
using Oblig1;

namespace Oblig1Test
{
    public class FamAppTest
    {
        [Test]
        public void TestWithChild()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("SHOW 3");
            var expectedResponse = "Haakon Magnus (Id=3) Født: 1973 Far: Harald (Id=6)\n"
                                   + "  Barn:\n"
                                   + "    Sverre Magnus (Id=1) Født: 2005\n"
                                   + "    Ingrid Alexandra (Id=2) Født: 2004\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
        [Test]
        public void TestNoChild()
        {
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var metteMarit = new Person { Id = 4, FirstName = "Mette-Marit", BirthYear = 1973 };
            ingridAlexandra.Father = haakon;
            ingridAlexandra.Mother = metteMarit;

            var app = new FamilyApp(metteMarit, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("SHOW 2");
            var expectedResponse = "Ingrid Alexandra (Id=2) Født: 2004 Far: Haakon Magnus (Id=3) Mor: Mette-Marit (Id=4)\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}