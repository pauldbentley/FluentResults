namespace FluentResults.Extensions.AspNetCore
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistrar
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ActionResultTranslatorFactory>();
            services.AddScoped<IActionResultTranslator<Success>, SuccessTranslator>();
            services.AddScoped<IActionResultTranslator<Error>, ErrorTranslator>();
            services.AddScoped<IActionResultTranslator<NotFoundError>, NotFoundErrorTranslator>();
            services.AddScoped<IActionResultTranslator<CreatedSuccess>, CreatedSuccessTranslator>();
            services.AddScoped<IActionResultTranslator<BadRequestError>, BadRequestErrorTranslator>();
            services.AddScoped<IActionResultTranslator<ProblemError>, ProblemErrorTranslator>();
            services.AddScoped<IActionResultTranslator<ValidationProblemError>, ValidationProblemErrorTranslator>();
            services.AddScoped<IActionResultTranslator<ForbidError>, ForbidErrorTranslator>();

            return services;
        }
    }
}
