//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Brokers.DateTimes;
using Sofee.Prosurer.Brokers.Storages;
using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Models.Users.Exceptions;
using System.Threading.Tasks;

namespace Sofee.Prosurer.Services.Users
{
    internal partial class UserService
    {
        private readonly StorageBroker storageBroker;
        private readonly DateTimeBroker dateTimeBroker;

        public UserService()
        {
            this.storageBroker = new StorageBroker();
            this.dateTimeBroker = new DateTimeBroker();
        }

        /// <exception cref="NullUserException"></exception>
        /// <exception cref="InvalidUserException"></exception>
        internal Task<User> AddUserAsync(User user)
        {
            ValidateUserOnAdd(user);

            return this.storageBroker.InsertUserAsync(user);
        }
    }
}