using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit.Sdk;

namespace TestDate
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(1, "день")]
        [DataRow(2, "дня")]
        [DataRow(3, "дня")]
        [DataRow(4, "дня")]
        [DataRow(5, "дней")]
        [DataRow(91, "день")]
        [DataRow(24, "дня")]
        public void GetDayDeclinationTest_CorrectValues_CorrertResult(int day, string expectedResult)
        {
            //Arrange
            

            //Action

            string actualResult = Program.GetDayDeclination(day);

            //Assert
            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void GetDayDeclinationTest_NegativeValue_ArgumentException()
        {
            //Arrange

            int day = -1;

            Exception exception = null;

            // Assert            
            Assert.ThrowsException<ArgumentException>(() => Program.GetDayDeclination(day));
        }

    }
}