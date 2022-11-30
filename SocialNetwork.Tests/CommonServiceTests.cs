using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Services.Services;
using System;

namespace SocialNetwork.Tests
{
    [TestClass]
    public class CommonServiceTests
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

            CommonService commonService = new CommonService();
            //Action

            string actualResult = commonService.DeclinationOfTheDay(day);

            //Assert
            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void GetDayDeclinationTest_NegativeValue_ArgumentException()
        {
            //Arrange
            CommonService commonService = new CommonService();
            int day = -1;

            Exception exception = null;

            // Assert            
            Assert.ThrowsException<ArgumentException>(() => commonService.DeclinationOfTheDay(day));
        }
    }
}
