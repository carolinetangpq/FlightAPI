using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFlightInfo.Exceptions
{
    public class RecordNotFoundException : Exception
    {

        public RecordNotFoundException(string msg) : base(msg) { }
    }

    
}
