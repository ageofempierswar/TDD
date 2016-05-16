using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_TravelAgency
{
    public class Tour
    {
        public string TourName { get; private set; }
        public DateTime TourDate { get; private set; }
        public int NumberOfSeats { get; private set; }

        public Tour(string tourName, DateTime tourDate, int numberOfSeats)
        {
            TourName = tourName;
            TourDate = tourDate;
            NumberOfSeats = numberOfSeats;
        }
    }
}
