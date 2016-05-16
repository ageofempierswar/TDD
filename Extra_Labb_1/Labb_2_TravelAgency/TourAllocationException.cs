using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Labb_2_TravelAgency
{
    [Serializable]
    public class TourAllocationException : Exception
    {
        public TourAllocationException()
        {
        }

        public TourAllocationException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public TourAllocationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TourAllocationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
