using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using Labb_2_TravelAgency;
using NUnit.Framework;
namespace Labb_2_TravelAgencyTest
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub _tourScheduleStub;
        private BookingSystem _sut;
        private Passenger _passenger;
        private Tour _tour;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _tourScheduleStub = new TourScheduleStub();
            _sut = new BookingSystem(_tourScheduleStub);
            _passenger = new Passenger { FirstName = "Carl", LastName = "Sanderson" };
            _tour = new Tour("Caminando", new DateTime(2015, 3, 6), 2);
        }

        [Test]
        public void CanCreateBooking()
        {
            //Act
            _tourScheduleStub.Tours = new List<Tour> { _tour };
            _sut.CreateBooking(_tour.TourName, _tour.TourDate, _passenger);
            var listOfBookings = _sut.GetBookings(_passenger);
            //Assert
            Assert.AreEqual(1, listOfBookings.Count);
            Assert.AreEqual(listOfBookings.First().Tour.TourName, _tour.TourName);
            Assert.AreEqual(listOfBookings.First().Passengers.First().FirstName, _passenger.FirstName);
        }

        [Test]
        public void CanNotBookPassengerOnNonExistingTour()
        {
            //Assert
            Assert.Throws<CanNotBookPassengerOnNonExistingTourException>(() =>
            {
                _sut.CreateBooking("Non existing tour", new DateTime(2015, 4, 5), _passenger);
            });
        }

        [Test]
        public void CanNotBookMorePassengersThanSeatsAvaliable()
        {
            //Act
            _tourScheduleStub.Tours = new List<Tour> { _tour };
            _sut.CreateBooking(_tour.TourName, _tour.TourDate, _passenger);
            _sut.CreateBooking(_tour.TourName, _tour.TourDate, _passenger);
            _sut.CreateBooking(_tour.TourName, _tour.TourDate, _passenger);

            //Assert

            Assert.Throws<CanNotBookMorePassengersThanSeatsAvaliableException>(() =>
            {
                _sut.CreateBooking(_tour.TourName, _tour.TourDate, _passenger);
            });
        }
    }
}
