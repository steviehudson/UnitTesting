using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTesting;

namespace UnitTestingTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        public void AreCollectionsEqual()
        {
            //Arrange
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Stephanie", LastName = "Hudson" });
            peopleExpected.Add(new Person() { FirstName = "Stevie", LastName = "Huds" });
            peopleExpected.Add(new Person() { FirstName = "Steph", LastName = "Hud" });

            //Act
            peopleActual = mgr.GetPeople();
            peopleExpected = peopleActual;

            //Assert
            //NOTE: Compare object not data
            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void AreCollectionsNotEqual()
        {
            //Arrange
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Stephanie", LastName = "Hudson" });
            peopleExpected.Add(new Person() { FirstName = "Stevie", LastName = "Huds" });

            //Act
            peopleActual = mgr.GetPeople();

            //Assert
            CollectionAssert.AreNotEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void IsCollectionOfTypeTest()
        {
            //Arrange
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }

        [TestMethod]
        public void AreCollectionsEquivalentTest()
        {
            //Arrange
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual;

            //Act
            peopleActual = mgr.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            //Assert
            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void AreCollectionsEqualWithComparerTest()
        {
            //Arrange
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual;

            //Act
            peopleActual = mgr.GetPeople();

            peopleExpected.Add(new Person() { FirstName = "Stephanie", LastName = "Hudson" });
            peopleExpected.Add(new Person() { FirstName = "Stevie", LastName = "Huds" });
            peopleExpected.Add(new Person() { FirstName = "Steph", LastName = "Hud" });

            //Assert
            CollectionAssert.AreEqual(peopleExpected, peopleActual,
                Comparer<Person>.Create((x,y) => 
                x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }

    }
}
