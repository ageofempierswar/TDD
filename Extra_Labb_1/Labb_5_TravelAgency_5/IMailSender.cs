using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_5_TravelAgency_5
{
    public interface IMailSender
    {
        void SendMail(string recipient, string message);
    }
}
