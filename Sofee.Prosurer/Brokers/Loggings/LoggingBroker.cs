//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using System;
using Xeptions;

namespace Sofee.Prosurer.Brokers.Loggings
{
    public class LoggingBroker
    {
        public void LoggingError(Xeption xeption) =>
            Console.WriteLine(xeption.Message);
    }
}
