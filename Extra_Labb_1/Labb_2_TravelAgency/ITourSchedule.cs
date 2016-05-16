using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_TravelAgency
{
    public interface ITourSchedule
    {
        void CreateTour(string name, DateTime date, int seats);
        List<Tour> GetToursFor(DateTime tourDate);
    }
}
