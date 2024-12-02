using System;
using System.Collections.Generic;

namespace EasyDriveRentals.Domain.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Customers = new HashSet<Customer>();
            RolMenus = new HashSet<RolMenu>();
            UserInfos = new HashSet<UserInfo>();
        }

        public int RolId { get; set; }
        public string? NameRol { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<RolMenu> RolMenus { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
