using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Labb_5_TravelAgency_5
{
    public class CanNotBookMorePassengersThanSeatsAvaliableException : Exception
    {
        public CanNotBookMorePassengersThanSeatsAvaliableException()
        {
        }

        public CanNotBookMorePassengersThanSeatsAvaliableException(string message) : base(message)
        {
        }

        public CanNotBookMorePassengersThanSeatsAvaliableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CanNotBookMorePassengersThanSeatsAvaliableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
