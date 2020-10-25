using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Exceptions
{
    public sealed class CommonException : Exception
    {
        public CommonException(string message) : base(message) { }

        public CommonException(string message, Exception ex) : base(message, ex) { }

        public CommonException(ICollection<Error> errors)
        {
            Errors = errors;
        }

        public CommonException(Error error)
        {
            Error = error;
        }

        public Error Error { get; private set; }

        public ICollection<Error> Errors { get; private set; }
    }
}
