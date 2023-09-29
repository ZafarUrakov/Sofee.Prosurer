//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using System;
using Xeptions;

namespace Sofee.Prosurer.Models.Users.Exceptions
{
    internal class FailedServiceUserException : Xeption
    {
        public FailedServiceUserException(Exception innerException)
            : base(message: "Failed user service error occurred, contact support.", innerException)
        { }
    }
}
