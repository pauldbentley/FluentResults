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

        public string? Location
        {
            get => Metadata.TryGetValue(nameof(Location), out object? value)
                ? (string?)value
                : default;

            private set => Metadata[nameof(Location)] = value;
        }

        public CreatedSuccess WithLocation(string location)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
            return this;
        }

        public CreatedSuccess WithLocation(Uri location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            return location.IsAbsoluteUri
                ? WithLocation(location.AbsoluteUri)
                : WithLocation(location.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped));
        }
    }
}
