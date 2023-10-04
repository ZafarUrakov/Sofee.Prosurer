//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sofee.Prosurer.Models.Users;
using Xunit;

namespace Sofee.Prosurer.Tests.Unit.Services.Users
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldAddUserAsync()
        {
            //given
            User randomUser = CreateRandomUser();
            User inputUser = randomUser;
            User persistedUser = inputUser;
            User expecteduser = persistedUser.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertUserAsync(inputUser)).ReturnsAsync(persistedUser);

            //when
            User actualUser = await this.userService.AddUserAsync(inputUser);

            //then
            actualUser.Should().BeEquivalentTo(expecteduser);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertUserAsync(inputUser), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
