using Sofee.Prosurer.Models.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofee.Prosurer.Brokers.Logging
{
    internal class LoggingBroker
    {
        public void LoggingError(NullUserException nullUserException) =>
            Console.WriteLine(nullUserException.Message);
    }
}
