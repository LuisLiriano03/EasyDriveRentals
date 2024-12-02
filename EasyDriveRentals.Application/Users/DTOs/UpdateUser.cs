﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Users.DTOs
{
    public class UpdateUser
    {
        public int Id { get; set; }
        public string? IdNumber { get; set; }
        public string? FullName { get; set; }
        public int? GenderId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? RolId { get; set; }

    }

}