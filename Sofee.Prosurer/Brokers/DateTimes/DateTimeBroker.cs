//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using System;

namespace Sofee.Prosurer.Brokers.DateTimes
{
    public class DateTimeBroker
    {
        internal DateTimeOffset GetDateTimeOffset() =>
            DateTimeOffset.UtcNow;
    }
}