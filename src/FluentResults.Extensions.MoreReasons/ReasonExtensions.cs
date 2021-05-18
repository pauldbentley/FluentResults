namespace FluentResults
{
    public static class ReasonExtensions
    {
        public static TValue GetMetadataOrDefault<TValue>(this Reason reason, string key) =>
            reason.HasMetadataKey(key)
                ? (TValue)reason.Metadata[key]
                : default;
    }
}
