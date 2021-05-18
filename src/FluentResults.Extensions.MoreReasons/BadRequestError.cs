namespace FluentResults
{
    public class BadRequestError : Error
    {
        public object Error
        {
            get => this.GetMetadataOrDefault<object>(nameof(Error));
            private set => Metadata[nameof(Error)] = value;
        }

        public BadRequestError WithError(object error)
        {
            Error = error;
            return this;
        }
    }
}
