using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_5_TravelAgency_5
{
    public class TourSchedule : ITourSchedule
    {
        private readonly List<Tour> _listOfTours = new List<Tour>();

        public void CreateTour(string name, DateTime date, int seats)
        {
            var listOfToursOnSameDate = GetToursFor(date);
            if (listOfToursOnSameDate.Count <= 2)
            {
                _listOfTours.Add(new Tour(name, date.Date, seats));
            }
            else
            {
                throw new TourAllocationException(
                    $"Cannot schedule three tours on same date. Next available date is: ");
            }
        }

        public List<Tour> GetToursFor(DateTime tourDate)
        {

            return (from tours in _listOfTours
                    where tours.TourDate == tourDate
                    select tours).ToList() ?? new List<Tour>();
        }

    }
}
