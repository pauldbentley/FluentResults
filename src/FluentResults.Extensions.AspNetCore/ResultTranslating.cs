namespace FluentResults.Extensions.AspNetCore
{
    using FluentResults;
    using Microsoft.AspNetCore.Mvc;

    public class ResultTranslating
    {
        public ResultTranslating(
            ResultBase result,
            ControllerBase controller)
        {
            Result = result;
            Controller = controller;

            IsValueResult = result.GetType().IsGenericType;

            Value = IsValueResult
                ? ((dynamic)result).ValueOrDefault
                : null;
        }

        public ResultBase Result { get; }

        public ControllerBase Controller { get; }

        public object? Value { get; }

        public bool IsValueResult { get; }
    }
}
