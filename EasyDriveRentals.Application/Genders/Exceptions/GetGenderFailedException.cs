using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDriveRentals.Application.Genders.Exceptions
{
    public class GetGenderFailedException : Exception
    {
        public override string Message { get; }

        public GetGenderFailedException() : base()
        {
            Message = "No role found";
        }

    }
}
