using System;

namespace AppService.Interfaces.Exceptions
{
    public class LowQuantityException : Exception
    {
        public LowQuantityException(string message) : base(message)
        {
            
        }

        public LowQuantityException()
        {
            
        }
    }
}