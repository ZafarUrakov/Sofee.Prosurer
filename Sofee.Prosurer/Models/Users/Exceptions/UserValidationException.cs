//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Xeptions;

namespace Sofee.Prosurer.Models.Users.Exceptions
{
    internal partial class UserValidationException : Xeption
    {
        public UserValidationException(Xeption innerException)
            : base(message: "User validation error occurred. Fix the errors and try again",
                  innerException)
        { }
    }
}
