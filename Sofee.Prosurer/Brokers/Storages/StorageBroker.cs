//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Sofee.Prosurer.Models.Users;

namespace Sofee.Prosurer.Brokers.Storages
{
    internal class StorageBroker : EFxceptionsContext
    {
        public DbSet<User> Users { get; set; }

        public StorageBroker() =>
            this.Database.EnsureCreated();

        public async Task<User> InsertUserAsync(User user)
        {
            await this.Users.AddAsync(user);
            await this.SaveChangesAsync();

            return user;
        }

        public async Task<User> SelectUserByIdAsync(Guid userId) =>
            await Users.FindAsync(userId);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=..\\..\\..\\Sofee.db";
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
