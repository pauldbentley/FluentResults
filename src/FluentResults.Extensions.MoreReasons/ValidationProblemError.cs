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

        public string? Key
        {
            get => Metadata.TryGetValue(nameof(Key), out object? value)
                ? (string?)value
                : default;

            set => Metadata[nameof(Key)] = value;
        }

        public ValidationProblemError WithKey(string key)
        {
            Key = key;
            return this;
        }
    }
}
