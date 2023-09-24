//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Brokers.DateTimes;
using Sofee.Prosurer.Brokers.Storages;
using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Models.Users.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sofee.Prosurer.Services.Users
{
    internal class UserService : DateTimeBroker
    {
        private readonly StorageBroker storageBroker;

        public UserService() =>
            this.storageBroker = new StorageBroker();

        /// <exception cref="NullUserException"></exception>
        /// <exception cref="InvalidUserException"></exception>
        internal Task<User> AddUserAsync(User user)
        {
            if (user is null)
                throw new NullUserException();

            Validate(
                (Rule: IsInvalid(user.Id), Parameter: nameof(User.Id)),
                (Rule: IsInvalid(user.Firstname), Parameter: nameof(User.Firstname)),
                (Rule: IsInvalid(user.Email), Parameter: nameof(User.Email)),
                (Rule: IsInvalid(user.GroupId), Parameter: nameof(User.GroupId)));

            Validate(
               (Rule: IsInvalidBirthDate(user.BirthDate), Parameter: nameof(User.BirthDate)),
            (Rule: IsInvalid(user.Email), Parameter: nameof(User.Email)));


            return this.storageBroker.InsertUserAsync(user);
        }

        private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is requred"
        };

        private dynamic IsInvalideEmail(string email) => new
        {
            Condition = Regex.IsMatch(email,@"^(.+)@(.+)$"),
            Message = "Email is invalide"
        };

        private void Validate(params(dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if(rule.Condition)
                {
                    invalidUserException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidUserException.ThrowIfContainsErrors(); ;
        }
    }
}
