using System;
using System.Collections.Generic;

namespace EasyDriveRentals.Domain.Entities
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? GenderId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public int? RolId { get; set; }
        public string? IdType { get; set; }
        public string? IdNumber { get; set; }
        public string? DriverLicenseNumber { get; set; }
        public string? LicenseIssuingCountry { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public string? IdPhoto { get; set; }
        public string? PhotoPassport { get; set; }
        public string? PhotoDriverLicense { get; set; }
        public string? PhotoAdditionalDocument { get; set; }
        public string? Comments { get; set; }
        public bool? RentalFrequency { get; set; }
        public bool? IsVip { get; set; }
        public decimal? AppliedDiscount { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual GenderInfo? Gender { get; set; }
        public virtual Rol? Rol { get; set; }
    }
}
