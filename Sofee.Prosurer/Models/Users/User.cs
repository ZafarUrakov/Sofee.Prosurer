//=================================
// Copyright (c) Sofee LLC.
// Powering True Leadership
//===============================

using System;

namespace Sofee.Prosurer.Models.Users
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffSet BirthDate { get; set; }
        public Guid GroupId { get; set; }
    }
}
