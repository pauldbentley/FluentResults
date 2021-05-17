namespace FluentResults
{
    public class ProblemError : Error
    {
        public string? Detail
        {
            get => Metadata.TryGetValue(nameof(Detail), out object? value)
                ? (string?)value
                : default;

            private set => Metadata[nameof(Detail)] = value;
        }

        public string? Instance
        {
            get => Metadata.TryGetValue(nameof(Instance), out object? value)
                ? (string?)value
                : default;

            private set => Metadata[nameof(Instance)] = value;
        }

        public int? StatusCode
        {
            get => Metadata.TryGetValue(nameof(StatusCode), out object? value)
                ? (int?)value
                : default;

            private set => Metadata[nameof(StatusCode)] = value;
        }

        public string? Title
        {
            get => Metadata.TryGetValue(nameof(Title), out object? value)
                ? (string?)value
                : default;

            private set => Metadata[nameof(Title)] = value;
        }

        public string? Type
        {
            get => Metadata.TryGetValue(nameof(Type), out object? value)
                ? (string?)value
                : default;

            private set => Metadata[nameof(Type)] = value;
        }
    }
}
