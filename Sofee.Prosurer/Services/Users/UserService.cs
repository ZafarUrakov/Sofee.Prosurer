﻿//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Brokers.DateTimes;
using Sofee.Prosurer.Brokers.Storages;
using Sofee.Prosurer.Models.Users;
using System.Threading.Tasks;

namespace Sofee.Prosurer.Services.Users
{
    internal partial class UserService
    {
        private readonly StorageBroker storageBroker;
        private readonly DateTimeBroker dateTimeBroker;

        public UserService(StorageBroker storageBroker, DateTimeBroker dateTimeBroker)
        {
            this.storageBroker = new StorageBroker();
            this.dateTimeBroker = new DateTimeBroker();
        }

        internal Task<User> AddUserAsync(User user) =>
        TryCatch(() =>
        {
            ValidateUserOnAdd(user);

            return this.storageBroker.InsertUserAsync(user);
        });
    }
}