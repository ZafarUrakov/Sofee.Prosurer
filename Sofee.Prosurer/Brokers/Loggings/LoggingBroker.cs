//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Models.Users.Exceptions;
using System;

namespace Sofee.Prosurer.Brokers.Loggings
{
    internal class LoggingBroker
    {
        public void LoggingError(NullUserException nullUserException) =>
            Console.WriteLine(nullUserException.Message);
    }
}
