//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Models.Users.Exceptions;
using System.Threading.Tasks;

namespace Sofee.Prosurer.Services.Users
{
    internal partial class UserService
    {
        private delegate Task<User> ReturningUserFunction();

        private Task<User> TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return returningUserFunction();
            }
            catch (NullUserException nullUserException)
            {
                var userValidationException =
                    new UserValidationException(nullUserException);

                throw userValidationException;
            }
            catch (InvalidUserException invalidUserException)
            {
                var userValidationException =
                   new UserValidationException(invalidUserException);

                throw userValidationException;
            }
        }
    }
}
