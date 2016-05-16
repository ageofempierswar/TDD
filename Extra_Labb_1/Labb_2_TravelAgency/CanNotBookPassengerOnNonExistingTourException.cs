using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Labb_2_TravelAgency
{
    [Serializable]
    public class CanNotBookPassengerOnNonExistingTourException : Exception
    {
        public CanNotBookPassengerOnNonExistingTourException()
        {
        }

        public CanNotBookPassengerOnNonExistingTourException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public CanNotBookPassengerOnNonExistingTourException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CanNotBookPassengerOnNonExistingTourException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
