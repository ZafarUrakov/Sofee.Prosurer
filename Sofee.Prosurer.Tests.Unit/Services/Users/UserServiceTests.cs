//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using Moq;
using Sofee.Prosurer.Brokers.Storages;
using Sofee.Prosurer.Models.Users;
using Sofee.Prosurer.Services.Users;
using Tynamix.ObjectFiller;

namespace Sofee.Prosurer.Tests.Unit.Services.Users
{
    public partial class UserServiceTests
    {
        private readonly Mock<StorageBroker> storageBrokerMock;
        private readonly UserService userService;

        public UserServiceTests()
        {
            this.storageBrokerMock = new Mock<StorageBroker>();

            this.userService = new UserService(
                storageBroker: this.storageBrokerMock.Object);
        }

        private DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private User CreateRandomUser() =>
            CreateUserFiller(GetRandomDateTimeOffset()).Create();

        private Filler<User> CreateUserFiller(DateTimeOffset dates)
        {
            var filler = new Filler<User>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            return filler;
        }
    }
}
