//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Brokers.Storages;
using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Models.Users.Exceptions;
using System.Threading.Tasks;

namespace Sofee.Prosurer.Services.Users
{
    internal class UserService
    {
        private readonly StorageBroker storageBroker;

        public UserService() =>
            this.storageBroker = new StorageBroker();

        /// <exception cref="NullUserException"></exception>
        internal Task<User> AddUserAsync(User user)
        {
            if (user is null)
                throw new NullUserException();

            return this.storageBroker.InsertUserAsync(user);
        }
    }
}
