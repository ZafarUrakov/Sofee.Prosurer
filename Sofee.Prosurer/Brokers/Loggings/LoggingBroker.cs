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
        public void LoggingError(Exception exception) =>
            Console.WriteLine(exception.Message);
    }
}
