//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Brokers.DateTimes;
using Sofee.Prosurer.Brokers.Storages;
using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Services.Users;
using System;
using System.Threading.Tasks;

namespace Sofee.Prosurer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            UserService userService = new UserService(
                storageBroker: new StorageBroker(),
                dateTimeBroker: new DateTimeBroker());

            User user = new User
            {
                Id = Guid.NewGuid(),
                Firstname = "Alberd",
                Lastname = "Radriges",
                BirthDate = DateTimeOffset.Parse("1/1/2004"),
                Email = "Aradriges00@icom.com",
                PhoneNumber = "+1234567890",
                GroupId = Guid.NewGuid()
            };

            var persistedUser = await userService.AddUserAsync(user);

            Console.WriteLine(persistedUser.Id);
        }
    }
}
