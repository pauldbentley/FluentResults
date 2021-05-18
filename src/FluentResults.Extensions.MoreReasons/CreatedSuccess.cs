namespace FluentResults
{
    using System;

    public class CreatedSuccess : Success
    {
        public CreatedSuccess()
            : this("Created")
        {
        }

        public CreatedSuccess(string message)
            : base(message)
        {
        }

        public string Location
        {
            get => this.GetMetadataOrDefault<string>(nameof(Location));
            private set => Metadata[nameof(Location)] = value;
        }

        public CreatedSuccess WithLocation(string location)
        {
            Location = location;
            return this;
        }

        public CreatedSuccess WithLocation(Uri location)
        {
            return location.IsAbsoluteUri
                ? WithLocation(location.AbsoluteUri)
                : WithLocation(location.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped));
        }
    }
}
