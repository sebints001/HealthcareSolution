using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Application.Exceptions
{
    public class InvalidPatientDataException : Exception
    {
        public InvalidPatientDataException(string message)
            : base(message)
        {
        }
    }

}
