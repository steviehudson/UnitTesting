using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace UnitTestingTest
{
    [TestClass]
    public class PersonTest : TestBase
    {
        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            //Arrange
            PersonManager mgr = new PersonManager();
            Person per;

            //Act
            per = mgr.CreatePerson("Stephanie", "Hudson", true);

            //Assert
            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        public void IsNotInstanceOfTypeTest()
        {
            //Arrange
            PersonManager mgr = new PersonManager();
            Person per;

            //Act
            per = mgr.CreatePerson("Stephanie", "Hudson", false);

            //Assert
            Assert.IsNotInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        public void IsNullTest()
        {
            //Arrange
            PersonManager mgr = new PersonManager();
            Person per;

            //Act
            per = mgr.CreatePerson("", "Hudson", true);

            //Assert
            Assert.IsNull(per)
;        }
    }
}
