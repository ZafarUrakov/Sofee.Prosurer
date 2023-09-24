//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using System;

namespace Sofee.Prosurer.Brokers.DateTimes
{
    internal class DateTimeBroker
    {

        protected dynamic IsInvalidBirthDate(DateTimeOffset birthDate)
        {
            var today = DateTimeOffset.UtcNow;
            var age = today.Year - birthDate.Year;

            if (birthDate.Month > today.Month)
                age--;

            return new
            {
                Condition = age < 6,
                Message = "User must be 6 years old or older"
            };
        }
    }
}