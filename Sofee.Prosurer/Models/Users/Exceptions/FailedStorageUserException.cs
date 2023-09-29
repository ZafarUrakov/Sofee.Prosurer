//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using System;
using Xeptions;

namespace Sofee.Prosurer.Models.Users.Exceptions
{
    internal class FailedStorageUserException : Xeption
    {
        public FailedStorageUserException(Exception innerException)
            : base(message: "Failed user storage error occurred, contact support.", innerException)
        { }
    }
}
