﻿namespace CoW.Application.Exceptions
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException(string message) : base(message)
        {
        }
        public UnAuthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
