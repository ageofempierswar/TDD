using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Labb_1_CoinChangerApplication;
namespace Labb_1_CoinChangerApplicationTests
{
    [TestFixture]
    public class CoinChangerTests
    {
        [Test]
        public void CorrectChangeWhenUsingOneCoinType()
        {
            //Arrange
            var coinTypes = new List<decimal> { 1.0m };
            var sut = new CoinChanger(coinTypes);
            //Act
            Dictionary<decimal, int> myChange = sut.MakeChange(14.0m);
            //Assert
            Assert.AreEqual(14, myChange[1m]);
        }

        [Test]
        public void CorrectChangeWhenUsingTwoCoinTypes()
        {
            //Arrange
            var coinTypes = new List<decimal> { 1.0m, 5.0m };
            var sut = new CoinChanger(coinTypes);
            //Act
            Dictionary<decimal, int> myChange = sut.MakeChange(14.0m);
            //Assert
            Assert.AreEqual(4, myChange[1m]);
        }
        [Test]
        public void CorrectChangeWhenUsingCoinsInDifferentOrder()
        {
            //Arrange
            var coinTypes = new List<decimal> { 10.0m, 2.0m, 5.0m };
            var sut = new CoinChanger(coinTypes);
            //Act
            Dictionary<decimal, int> myChange = sut.MakeChange(47.0m);
            //Assert
            Assert.AreEqual(4, myChange[10m]);
        }
        [Test]
        public void CorrectChangeWhenUsingCoinsNotWholeNumbers()
        {
            //Arrange
            var coinTypes = new List<decimal> { 0.25m, 0.5m, 1.0m, 5.0m };
            var sut = new CoinChanger(coinTypes);
            //Act
            Dictionary<decimal, int> myChange = sut.MakeChange(13.75m);
            //Assert
            Assert.AreEqual(2, myChange[5m]);
        }
    }
}