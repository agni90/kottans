using FindElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FindElementsTests
{
    [TestClass]
    public class ProgramTests
    {
        private static Checkers classUnderTest;
        [ClassInitialize]
        public static void Init(TestContext tc)
        {
            classUnderTest = new Checkers();
        }

        [TestMethod]
        public void CheckForPrint_PassCorrectValue_Success()
        {
            string value = "-print hihi";
            bool expectedResult = true;
            var result = classUnderTest.CheckForPrint(value);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CheckForPrint_PassIncorrectValue_Success()
        {
            string value = "-printt hihi";
            bool expectedResult = false;
            var result = classUnderTest.CheckForPrint(value);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CheckForHelp_PassCorrectValue_Success()
        {
            string value = "-help";
            bool expectedResult = true;
            var result = classUnderTest.CheckForHelp(value);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CheckForHelp_PassInCorrectValue_Success()
        {
            string value = "-helps";
            bool expectedResult = false;
            var result = classUnderTest.CheckForHelp(value);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CheckForK_PassCorrectValue_Success()
        {
            string value = "-k value key";
            bool expectedResult = true;
            var result = classUnderTest.CheckForK(value);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CheckForK_PassInCorrectValue_Success()
        {
            string value = "k value key";
            bool expectedResult = false;
            var result = classUnderTest.CheckForK(value);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CheckForPing_PassCorrectValue_Success()
        {
            string value = "-ping";
            bool expectedResult = true;
            var result = classUnderTest.CheckForPing(value);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CheckForPing_PassInCorrectValue_Success()
        {
            string value = "-pinging";
            bool expectedResult = false;
            var result = classUnderTest.CheckForPing(value);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CheckIsCommandCorrect_PassCorrectValue_Success()
        {
            string value = "test";
            bool expectedResult = true;
            var result = classUnderTest.CheckIsCommandCorrect(value);
            Assert.AreEqual(result, expectedResult);
        }

       }
}
