using System;

namespace SF.Services.Interfaces.CustomExceptions
{
    [Serializable]
    public class BadArgumentException : Exception
    {
        public BadArgumentException(string message) : base(message)
        {
        }
    }
}
