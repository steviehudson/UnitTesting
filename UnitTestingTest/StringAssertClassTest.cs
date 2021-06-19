using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace UnitTestingTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        public void ContainsTest()
        {
            //Arrange
            string str1 = "Stephanie Hudson";
            string str2 = "Stephanie";

            //Assert
            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        public void StartsWithTest()
        {
            //Arrange
            string str1 = "Stephanie Hudson";
            string str2 = "Stephanie";

            //Assert
            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCase()
        {
            //Arrange
            Regex r = new Regex(@"^([^A-Z])+$");

            //Assert
            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        public void IsNotAllLowerCase()
        {
            //Arrange
            Regex r = new Regex(@"^([^A-Z])+$");

            //Assert
            StringAssert.DoesNotMatch("All lower case", r);
        }
    }
}
