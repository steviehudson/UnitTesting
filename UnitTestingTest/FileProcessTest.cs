using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;
using System;
using System.IO;

namespace UnitTestingTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        private const string BAD_FILE_NAME = @"C:\NotExists.bad";

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

            if (TestContext.TestName.StartsWith("FileNameDoesExist")) 
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
        [Description("Check to see if filename exists")]
        [Owner("Stephanie")]
        [Priority(1)]
        [TestCategory("NoException")]
        //[Ignore]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;         

            //Act
            TestContext.WriteLine(@"Checking File" + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);

            //Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if filename does not exist")]
        [Owner("Stephanie")]
        [Priority(2)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            TestContext.WriteLine(@"Checking File " + BAD_FILE_NAME);
            fromCall = fp.FileExists(BAD_FILE_NAME);

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [Description("Check for a thrown ArgumentNullException using ExpectedException")]
        [Owner("Stevie")]
        [Priority(3)]
        [TestCategory("Exception")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            //Arrange
            FileProcess fp = new FileProcess();

            //Act
            TestContext.WriteLine(@"Checking for a NULL File");
            fp.FileExists(@"");
        }

        [TestMethod]
        [Description("Check for a thrown ArgumentNullException using Try Catch")]
        [Owner("Stevie")]
        [Priority(4)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            //Arrange
            FileProcess fp = new FileProcess();

            //Act
            TestContext.WriteLine(@"Checking for a NULL File");

            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //Test was a success
                return;
            }

            ///Asert
            //Fail the test
            Assert.Fail("Call to FileExists() did NOT throw an ArgumentNullException.");
        }

        [TestMethod]
        [DeploymentItem("FileToDeploy.txt")]
        [DataRow(@"C:\README.md", DisplayName = "README.md")]
        [DataRow("FileToDeploy.txt", DisplayName = "Deployment Item: FileToDeploy.txt")]
        public void FileNameUsingDataRow(string fileName)
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            if (!fileName.Contains(@"\"))
            {
                fileName = TestContext.DeploymentDirectory + @"\" + fileName;
            }

            //Act
            TestContext.WriteLine("Checking File " + fileName);
            fromCall = fp.FileExists(fileName);

            //Assert
            Assert.IsTrue(fromCall);
        }
    }
}
