using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit.Sdk;

namespace TestDate
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(1, "����")]
        [DataRow(2, "���")]
        [DataRow(3, "���")]
        [DataRow(4, "���")]
        [DataRow(5, "����")]
        [DataRow(91, "����")]
        [DataRow(24, "���")]
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