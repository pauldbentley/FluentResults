namespace FluentResults
{
    public class ValidationProblemError : Error
    {
        public ValidationProblemError()
        {
        }

        public ValidationProblemError(string message)
            : base(message)
        {
        }

        public string Key
        {
            get => this.GetMetadataOrDefault<string>(nameof(Key));
            set => Metadata[nameof(Key)] = value;
        }

        public ValidationProblemError WithKey(string key)
        {
            Key = key;
            return this;
        }
    }
}
