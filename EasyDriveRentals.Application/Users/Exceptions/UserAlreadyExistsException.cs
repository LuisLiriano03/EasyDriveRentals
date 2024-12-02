using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Users.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public override string Message { get; }

        public UserAlreadyExistsException( string errorMessage) : base(errorMessage)
        {
            Message = "The following fields already exist for another user: " + errorMessage;
        }

    }
}
