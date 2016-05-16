using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Labb_5_TravelAgency_5;
namespace Labb_5_TravelAgencyTest_5
{
    [TestFixture]
    public class BookingSystemTests
    {
        [SetUp]
        public void SetUp()
        {
            //Arrange
            _tourScheduleStub = new TourScheduleStub();
            _mailSender = Substitute.For<IMailSender>();
            _sut = new BookingSystem(_tourScheduleStub, _mailSender);
            _passenger = new Passenger
            {
                FirstName = "Carl",
                LastName = "Sanderson",
                Email = "carl@example.com"
            };
            _tour = new Tour("Caminando", new DateTime(2015, 3, 6), 2);
            _mailSender.SendMail(_passenger.Email, $"Welcome to our {_tour.TourName}! This tour will start at {_tour.TourDate}.");
        }

        private TourScheduleStub _tourScheduleStub;
        private BookingSystem _sut;
        private Passenger _passenger;
        private Tour _tour;
        private IMailSender _mailSender;

        [Test]
        public void CanCreateBooking()
        {
            //Act
            _tourScheduleStub.Tours = new List<Tour> { _tour };
            _sut.CreateBooking(_tour.TourName, _tour.TourDate, _passenger);
            var listOfBookings = _sut.GetBookings(_passenger);
            //Assert
            Assert.AreEqual(1, listOfBookings.Count);
            Assert.AreSame(listOfBookings.First().Tour.TourName, _tour.TourName);
            Assert.AreSame(listOfBookings.First().Passengers.First().FirstName, _passenger.FirstName);
        }

        [Test]
        public void CanNotBookMorePassengersThanSeatsAvaliable()
        {
            //Act
            _tourScheduleStub.Tours = new List<Tour> { _tour };
            _sut.CreateBooking("Caminando", new DateTime(2015, 3, 6), _passenger);
            _sut.CreateBooking("Caminando", new DateTime(2015, 3, 6), _passenger);
            _sut.CreateBooking("Caminando", new DateTime(2015, 3, 6), _passenger);

            //Assert
            Assert.Throws<CanNotBookMorePassengersThanSeatsAvaliableException>(
                () => { _sut.CreateBooking("Caminando", new DateTime(2015, 3, 6), _passenger); });
        }

        [Test]
        public void CanNotBookPassengerOnNonExistingTour()
        {
            //Assert
            Assert.Throws<CanNotBookPassengerOnNonExistingTourException>(
                () => { _sut.CreateBooking("Non existing _tour", new DateTime(2015, 4, 5), _passenger); });
        }

        [Test]
        public void CanSendConfirmationMail()
        {
            //Assert
            _mailSender.Received(1).SendMail(Arg.Is(_passenger.Email), Arg.Any<string>());
        }

        [Test]
        public void MailContainsDateAndTourName()
        {
            //Assert
            _mailSender.Received(1).SendMail(Arg.Is(_passenger.Email), Arg.Is<string>(s => s.Contains($"Welcome to our {_tour.TourName}! This tour will start at {_tour.TourDate}.")));//Ändra denna
        }
    }
}
