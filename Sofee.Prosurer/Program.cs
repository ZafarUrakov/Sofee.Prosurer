//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Sofee.Prosurer.Brokers.DateTimes;
using Sofee.Prosurer.Brokers.Loggings;
using Sofee.Prosurer.Brokers.Storages;
using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Services.Users;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using Sofee.Prosurer.Models.Users.Exceptions;
using Bogus;

namespace Sofee.Prosurer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            LoggingBroker loggingBroker = new LoggingBroker();
            UserService userService = new UserService(
                storageBroker: new StorageBroker(),
                dateTimeBroker: new DateTimeBroker());

            var fake = new Faker();

            for (int userIndex = 0; userIndex <= 2000; userIndex++)
            {
                var user = new User
                {
                    Id = fake.Random.Guid(),
                    Firstname = fake.Name.FindName(),
                    Lastname = fake.Name.LastName(),
                    BirthDate = fake.Date.PastOffset(20, DateTime.Now.AddYears(-18)),
                    Email = fake.Internet.Email(),
                    PhoneNumber = "+" + fake.Phone.PhoneNumber(),
                    GroupId = fake.Random.Guid()
                };

                try
                {
                    var persistedClient = await userService.AddUserAsync(user);

                    Console.WriteLine($"User with id {persistedClient.Id} added.");
                }
                catch (UserValidationException userValidationException)
                {
                    foreach (DictionaryEntry entry in userValidationException.Data)
                    {
                        string errorSummary = string.Join(", ", (List<string>)entry.Value);

                        Console.WriteLine(entry.Key + " - " + errorSummary);
                    }
                    Console.WriteLine($"Message: {userValidationException.Message}");
                }
                catch (UserDependencyValidationException userDependencyValidationException)
                {
                    loggingBroker.LoggingError(userDependencyValidationException);

                    throw userDependencyValidationException;
                }
                catch (UserDependencyException userDependencyException)
                {
                    loggingBroker.LoggingError(userDependencyException);

                    throw userDependencyException;
                }
                catch (UserServiceException userServiceException)
                {
                    loggingBroker.LoggingError(userServiceException);

                    throw userServiceException;
                }
            }
        }
    }
}
