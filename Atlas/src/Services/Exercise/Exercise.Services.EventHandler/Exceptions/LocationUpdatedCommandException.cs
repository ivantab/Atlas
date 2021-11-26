using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Services.EventHandler.Exceptions
{
    public class LocationUpdatedCommandException : Exception
    {
        public LocationUpdatedCommandException(string message)
           : base (message)
        {

        }
    }
}
