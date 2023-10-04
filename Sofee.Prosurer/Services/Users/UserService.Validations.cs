//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Models.Users.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Sofee.Prosurer.Services.Users
{
    internal partial class UserService
    {
        private void ValidateUserOnAdd(User user)
        {
            ValidateUserNotNull(user);

            Validate(
                (Rule: IsInvalid(user.Id), Parameter: nameof(User.Id)),
                (Rule: IsInvalid(user.Firstname), Parameter: nameof(User.Firstname)),
                (Rule: IsInvalid(user.Email), Parameter: nameof(User.Email)),
                (Rule: IsInvalid(user.BirthDate), Parameter: nameof(User.BirthDate)),
                (Rule: IsLessThan12(user.BirthDate), Parameter: nameof(User.BirthDate)),
                (Rule: IsInvalid(user.GroupId), Parameter: nameof(User.GroupId)));

            Validate(
               (Rule: IsInvalid(user.Email), Parameter: nameof(User.Email)));
        }

        private static void ValidateUserNotNull(User user)
        {
            if (user is null)
                throw new NullUserException();
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

        private dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private dynamic IsLessThan12(DateTimeOffset date) => new
        {
            Condition = IsAgeLessThan12(date),
            Message = "Age is less than 12"
        };

        private bool IsAgeLessThan12(DateTimeOffset date)
        {
            DateTimeOffset now = this.dateTimeBroker.GetDateTimeOffset();
            int age = (now - date).Days / 365;

            return age < 12;
        }

        private dynamic IsInvalideEmail(string email) => new
        {
            Condition = Regex.IsMatch(email, @"^(.+)@(.+)$"),
            Message = "Email is invalide"
        };


        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
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
