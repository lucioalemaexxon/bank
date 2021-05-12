using System;

namespace Bank.Loans.Domain.Exceptions
{
    public class NotFoundDomainException : DomainException
    {
        public NotFoundDomainException() { }

        public NotFoundDomainException(string message) : base(message) { }

        public NotFoundDomainException(string message, Exception exception) : base(message, exception) { }
    }
}
