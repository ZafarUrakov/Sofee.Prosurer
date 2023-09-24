//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Xeptions;

namespace Sofee.Prosurer.Models.Users.Exceptions
{
    internal class NullUserException : Xeption
    {
        public NullUserException()
               : base(message: "Client is null")
        { }
    }
}
