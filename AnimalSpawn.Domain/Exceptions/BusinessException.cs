using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AnimalSpawn.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() : base()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }       
    }
}
