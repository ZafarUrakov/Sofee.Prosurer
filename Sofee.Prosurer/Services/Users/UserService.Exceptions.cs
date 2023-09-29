//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using EFxceptions.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Models.Users.Exceptions;
using System;
using System.Threading.Tasks;
using Xeptions;

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
                throw CreateValidationException(nullUserException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw CreateValidationException(invalidUserException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsClientException =
                    new AlreadyExistsUserException(duplicateKeyException);

                throw CreateDependencyValidationException(alreadyExistsClientException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedUserException =
                    new LockedUserException(dbUpdateConcurrencyException);

                throw CreateDependencyException(lockedUserException);

            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedStorageUserException =
                    new FailedStorageUserException(dbUpdateException);

                throw CreateDependencyException(failedStorageUserException);
            }
            catch (Exception exception)
            {
                var failedServiceUserException =
                    new FailedServiceUserException(exception);

                throw CreateServiceException(failedServiceUserException);
            }
        }

        private UserValidationException CreateValidationException(Xeption xeption)
        {
            var userValidationException =
                   new UserValidationException(xeption);

            return userValidationException;
        }

        private UserDependencyValidationException CreateDependencyValidationException(Xeption xeption)
        {
            var userDependencyValidationException =
                new UserDependencyValidationException(xeption);

            return userDependencyValidationException;
        }

        private UserDependencyException CreateDependencyException(Xeption xeption)
        {
            var userDependencyException =
                new UserDependencyException(xeption);

            return userDependencyException;
        }

        private UserServiceException CreateServiceException(Xeption xeption)
        {
            var userServiceException =
                new UserServiceException(xeption);

            return userServiceException;
        }
    }
}
