using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Roles.Exceptions
{
    public class GetRolFailedException : Exception
    {
        public override string Message { get; }

        public GetRolFailedException() : base()
        {
            Message = "No role found";
        }

    }
}
