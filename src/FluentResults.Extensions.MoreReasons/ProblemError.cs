namespace FluentResults
{
    public class ProblemError : Error
    {
        public ProblemError()
        {
        }

        public ProblemError(string detail)
            : base(detail)
        {
        }

        public string Detail
        {
            get => Message;
            private set => Message = value;
        }

        public string Instance
        {
            get => this.GetMetadataOrDefault<string>(nameof(Instance));
            private set => Metadata[nameof(Instance)] = value;
        }

        public int StatusCode
        {
            get => this.GetMetadataOrDefault<int>(nameof(StatusCode));
            private set => Metadata[nameof(StatusCode)] = value;
        }

        public string Title
        {
            get => this.GetMetadataOrDefault<string>(nameof(Title));
            private set => Metadata[nameof(Title)] = value;
        }

        public string Type
        {
            get => this.GetMetadataOrDefault<string>(nameof(Type));
            private set => Metadata[nameof(Type)] = value;
        }

        public ProblemError WithDetail(string detail)
        {
            Detail = detail;
            return this;
        }

        public ProblemError WithInstance(string instance)
        {
            Instance = instance;
            return this;
        }

        public ProblemError WithStatusCode(int statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

        public ProblemError WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public ProblemError WithType(string type)
        {
            Type = type;
            return this;
        }
    }
}
