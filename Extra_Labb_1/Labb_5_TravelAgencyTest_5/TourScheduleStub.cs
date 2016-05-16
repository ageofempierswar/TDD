using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_5_TravelAgency_5;
namespace Labb_5_TravelAgencyTest_5
{

    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours { private get; set; }
        public void CreateTour(string name, DateTime date, int seats)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetToursFor(DateTime tourDate)
        {
            return Tours ?? new List<Tour>();
        }

    }
}
