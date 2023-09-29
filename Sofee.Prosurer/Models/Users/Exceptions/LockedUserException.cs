//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using System;
using Xeptions;

namespace Sofee.Prosurer.Models.Users.Exceptions
{
    internal class LockedUserException : Xeption
    {
        public LockedUserException(Exception innerException)
            : base(message: "User is locked, try again later.", innerException)
        { }
    }
}
