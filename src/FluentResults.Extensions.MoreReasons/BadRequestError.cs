namespace FluentResults
{
    using System;

    public class BadRequestError : Error
    {
        public object? Error
        {
            get => Metadata[nameof(Error)];
            private set => Metadata[nameof(Error)] = value;
        }

        public BadRequestError WithError(object error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
            return this;
        }
    }
}
