namespace FluentResults.Extensions.AspNetCore
{
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class ControllerResultContext
    {
        public ControllerResultContext(
            ControllerBase controller,
            ResultBase result)
        {
            Controller = controller;
            Result = result;
            IsValueResult = result.GetType().IsGenericType;

            Value = IsValueResult
                ? ((dynamic)result).ValueOrDefault
                : null;
        }

        public ControllerBase Controller { get; }

        public ResultBase Result { get; }

        public object? Value { get; }

        public bool IsValueResult { get; }
    }
}
