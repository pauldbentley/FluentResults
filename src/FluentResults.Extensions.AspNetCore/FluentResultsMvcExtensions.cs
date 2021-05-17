namespace Microsoft.Extensions.DependencyInjection
{
    using FluentResults.Extensions.AspNetCore;

    public static class FluentResultsMvcExtensions
    {
        public static IMvcCoreBuilder AddFluentResults(this IMvcCoreBuilder builder)
        {
            ServiceRegistrar.RegisterServices(builder.Services);

            return builder;
        }

        public static IMvcBuilder AddFluentResults(this IMvcBuilder builder)
        {
            ServiceRegistrar.RegisterServices(builder.Services);

            return builder;
        }
    }
}
