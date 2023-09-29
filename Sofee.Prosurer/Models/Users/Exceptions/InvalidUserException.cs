//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Xeptions;

namespace Sofee.Prosurer.Models.Users.Exceptions
{
    internal class InvalidUserException : Xeption
    {
        public InvalidUserException()
            : base(message: "User is invalid. Fix the errors and try again.")
        { }
    }
}