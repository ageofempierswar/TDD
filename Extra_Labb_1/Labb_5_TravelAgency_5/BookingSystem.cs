using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_5_TravelAgency_5
{
    public class BookingSystem
    {
        private readonly ITourSchedule _iTourSchedule;
        private readonly IMailSender _mailSender;
        private readonly List<Booking> _listOfBookings;

        public BookingSystem(ITourSchedule iTourSchedule, IMailSender mailSender)
        {
            _iTourSchedule = iTourSchedule;
            _mailSender = mailSender;
            _listOfBookings = new List<Booking>();
        }

        public void CreateBooking(string tourName, DateTime tourDate, Passenger passenger)
        {
            var listOfTours = _iTourSchedule.GetToursFor(tourDate);
            if (listOfTours.Count == 0)
            {
                listOfTours = new List<Tour>();
            }

            var tour = listOfTours.FirstOrDefault(x => x.TourName == tourName);
            if (tour == null)
            {
                throw new CanNotBookPassengerOnNonExistingTourException();
            }

            var listOfPassengersForSpecificTour = _listOfBookings.Where(x => x.Tour.TourName == tourName).Select(y => y.Passengers).ToList();//Kan bli null, borde kolla i ifsatsen. Flata ut koden
            if (listOfPassengersForSpecificTour.Count <= tour.NumberOfSeats)
            {
                _listOfBookings.Add(new Booking
                {
                    Tour = tour,
                    Passengers = new List<Passenger> { passenger }
                });
                _mailSender.SendMail(passenger.Email, $"Welcome to our {tourName}! This tour will start at {tourDate}.");
            }
            else
            {
                throw new CanNotBookMorePassengersThanSeatsAvaliableException();
            }
        }

        public List<Booking> GetBookings(Passenger passenger)
        {
            return (from booking in _listOfBookings
                    where booking.Passengers.FirstOrDefault()?.FirstName == passenger.FirstName
                    select booking).ToList();
        }

    }
}
