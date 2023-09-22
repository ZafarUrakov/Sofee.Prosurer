//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Brokers.Storages;
using Sofee.Prosurer.Models.Users;

namespace Sofee.Prosurer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Firstname = "Test",
                Lastname = "Project",
                PhoneNumber = "1234567890",
                Email = "testEmail.dot"
            };

            using (var storageBroker = new StorageBroker())
            {
                await storageBroker.InsertUserAsync(user);
            }
        }
    }
}
