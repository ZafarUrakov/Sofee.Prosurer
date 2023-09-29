//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using System;

namespace Sofee.Prosurer.Brokers.DateTimes
{
    internal class DateTimeBroker
    {
        internal DateTimeOffset GetDateTimeOffset() =>
            DateTimeOffset.UtcNow;
    }
}