using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using UnitTesting;

namespace UnitTestingTest
{
    [TestClass]
    public class FileProcessOtherTest : TestBase
    {
        [ClassInitialize()]
        public static void ClassInitialization(TestContext tc)
        {
            //TODO: Initialization for all tests in class
            tc.WriteLine("In ClassInitialization() method");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //TODO: Clean up after all tests in class
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In TestInitialize() method");

            WriteDescription(GetType());

            if (TestContext.TestName.StartsWith("FileNamesDoesExistSimpleMessage"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    //Create the 'Good' file.
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("In TestCleanup() method");

            if (TestContext.TestName.StartsWith("FileNameDoeExist"))
            {
                //Delete file
                if (File.Exists(_GoodFileName))
                {
                    File.Delete(_GoodFileName);
                }
            }
        }

        [TestMethod]
        [DataRow(1, 1, DisplayName = "First Test (1,1)")]
        [DataRow(42, 42, DisplayName = "Second Test (42,42)")]
        public void AreNumbersEqual(int num1, int num2)
        {
            Assert.AreEqual(num1, num2);
        }

        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000);
        }

        [TestMethod]
        public void FileNamesDoesExistSimpleMessage()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File {0} Does Not Exist.", _GoodFileName);
        }

        [TestMethod]
        public void AreEqualTest()
        {
            //Arrange
            string str1 = "Stephanie";
            string str2 = "stephanie";

            //Assert
            Assert.AreEqual(str1, str2, true);
        }

        [TestMethod]
        public void AreNotEqualTest()
        {
            //Arrange
            string str1 = "Stephanie";
            string str2 = "stephanie";

            //Assert
            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        public void AreSameTest()
        {
            //Arrange
            FileProcess x = new FileProcess();
            FileProcess z = x;

            //Act
            Assert.AreSame(x, z);
        }

        [TestMethod]
        public void AreNotSameTest()
        {
            //Arrange
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();
            
            //Act
            Assert.AreNotSame(x, y);
        }
    }
}
