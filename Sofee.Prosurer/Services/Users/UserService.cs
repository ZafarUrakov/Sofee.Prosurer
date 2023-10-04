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
    public partial class UserService
    {
        private readonly StorageBroker storageBroker;
        private readonly DateTimeBroker dateTimeBroker;

        public UserService(StorageBroker storageBroker)
        {
            this.storageBroker = new StorageBroker();
        }

        public Task<User> AddUserAsync(User user) =>
        TryCatch(() =>
        {
            ValidateUserOnAdd(user);

            throw new System.NotImplementedException();
        });
    }
}