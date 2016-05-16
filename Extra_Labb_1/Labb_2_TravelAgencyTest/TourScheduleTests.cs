using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Labb_2_TravelAgency;
namespace Labb_2_TravelAgencyTest
{
    [TestFixture]
    public class TourScheduleTests
    {
        private TourSchedule _sut;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _sut = new TourSchedule();
        }
        [Test]
        public void CanCreateNewTour()
        {
            //Act
            _sut.CreateTour("New Years Safari", new DateTime(2015, 01, 01), 20);
            var toursOnGivenDate = _sut.GetToursFor(new DateTime(2015, 01, 01));
            //Assert
            Assert.AreEqual(1, toursOnGivenDate.Count);
            Assert.AreEqual("New Years Safari", toursOnGivenDate.First().TourName);
            Assert.AreEqual(20, toursOnGivenDate.First().NumberOfSeats);
        }
        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            //Act
            _sut.CreateTour("New Years Safari2", new DateTime(2015, 1, 1, 10, 15, 0), 20);
            var toursOnGivenDate = _sut.GetToursFor(new DateTime(2015, 1, 1));
            //Assert
            Assert.AreEqual(new DateTime(2015, 1, 1), toursOnGivenDate.First().TourDate.Date);
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            //Act
            _sut.CreateTour("London Tour", new DateTime(2015, 1, 22), 32);
            _sut.CreateTour("Paris", new DateTime(2014, 2, 22), 150);
            _sut.CreateTour("Calcutta", new DateTime(2016, 1, 23), 450);
            var toursOnGivenDate = _sut.GetToursFor(new DateTime(2014, 2, 22));
            //Assert
            Assert.AreEqual(1, toursOnGivenDate.Count);
        }

        [Test]
        public void ScheduleMoreThanThreeToursOnSameDate()
        {
            //Assert
            Assert.Throws<TourAllocationException>(() =>
            {
                _sut.CreateTour("London Tour2", new DateTime(2015, 1, 22), 32);
                _sut.CreateTour("Paris2", new DateTime(2015, 1, 22), 150);
                _sut.CreateTour("Calcutta2", new DateTime(2015, 1, 22), 450);
                _sut.CreateTour("Canberra Tour", new DateTime(2015, 1, 22), 500);
            });
        }
    }
}
