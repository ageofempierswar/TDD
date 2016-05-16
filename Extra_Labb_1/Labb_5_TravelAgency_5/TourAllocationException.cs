using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Labb_5_TravelAgency_5
{
    public class TourAllocationException : Exception
    {
        public TourAllocationException()
        {
        }

        public TourAllocationException(string message) : base(message)
        {
        }

        public TourAllocationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TourAllocationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
