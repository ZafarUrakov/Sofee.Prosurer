//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Xeptions;

namespace Sofee.Prosurer.Models.Users.Exceptions
{
    internal class UserDependencyException : Xeption
    {
        public UserDependencyException(Xeption innerException)
            : base(message: "User dependency error occurred, contact support.", innerException)
        { }
    }
}
