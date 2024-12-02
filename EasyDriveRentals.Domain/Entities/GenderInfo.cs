using System;
using System.Collections.Generic;

namespace EasyDriveRentals.Domain.Entities
{
    public partial class GenderInfo
    {
        public GenderInfo()
        {
            Customers = new HashSet<Customer>();
            UserInfos = new HashSet<UserInfo>();
        }

        public int GenderId { get; set; }
        public string? GenderName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
