using System;
using System.Runtime.Serialization;

namespace CarFuel.Models
{
    [Serializable]
    public class InvalidDtataException : Exception
    {
        public string PropertyName { get; }
        public InvalidDtataException(string propertyName, string message)
        {
        }

        public InvalidDtataException(string message) : base(message)
        {

        }

        public InvalidDtataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDtataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}