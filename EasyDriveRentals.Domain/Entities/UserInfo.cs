using System;
using System.Collections.Generic;

namespace EasyDriveRentals.Domain.Entities
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string? IdNumber { get; set; }
        public string? FullName { get; set; }
        public int? GenderId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public int? RolId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual GenderInfo? Gender { get; set; }
        public virtual Rol? Rol { get; set; }
    }
}
