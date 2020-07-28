namespace FileServer.Application.Common.Exceptions
{
    using System;

    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message) { }
    }
}