using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_TravelAgency
{
    public class BookingSystem
    {
        private readonly ITourSchedule _iTourSchedule;
        private readonly List<Booking> _listOfBookings;

        public BookingSystem(ITourSchedule iTourSchedule)
        {
            _iTourSchedule = iTourSchedule;
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

            var listOfPassengersForSpecificTour = _listOfBookings.Where(x => x.Tour.TourName == tourName).Select(y => y.Passengers).ToList();

            if (listOfPassengersForSpecificTour.Count <= tour.NumberOfSeats)
            {
                _listOfBookings.Add(new Booking
                {
                    Tour = tour,
                    Passengers = new List<Passenger> { passenger }
                });
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
