using System;

namespace SF.Services.Interfaces.CustomExceptions
{
    [Serializable]
    public class AccessForbiddenException : Exception
    {
        public AccessForbiddenException(string message) : base(message)
        {
        }
    }
}
