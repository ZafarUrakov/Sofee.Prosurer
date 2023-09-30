//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using EFxceptions.Models.Exceptions;
using Xeptions;

namespace Sofee.Prosurer.Models.Users.Exceptions
{
    internal class AlreadyExistsUserException : Xeption
    {
        private DuplicateKeyException duplicateKeyException;

        public AlreadyExistsUserException(Xeption innerException)
            : base(message: "User already exists.", innerException)
        { }

        public AlreadyExistsUserException(DuplicateKeyException duplicateKeyException)
        {
            this.duplicateKeyException = duplicateKeyException;
        }
    }
}
