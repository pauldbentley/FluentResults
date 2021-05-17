namespace FluentResults.Extensions.AspNetCore
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ControllerServiceRegistrar
    {
        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ActionResultTranslatorFactory<ControllerResultContext>>();
            services.AddScoped<IActionResultTranslator<Success, ControllerResultContext>, SuccessTranslator>();
            services.AddScoped<IActionResultTranslator<Error, ControllerResultContext>, ErrorTranslator>();
            services.AddScoped<IActionResultTranslator<NotFoundError, ControllerResultContext>, NotFoundErrorTranslator>();
            services.AddScoped<IActionResultTranslator<CreatedSuccess, ControllerResultContext>, CreatedSuccessTranslator>();
            services.AddScoped<IActionResultTranslator<BadRequestError, ControllerResultContext>, BadRequestErrorTranslator>();
            services.AddScoped<IActionResultTranslator<ProblemError, ControllerResultContext>, ProblemErrorTranslator>();
            services.AddScoped<IActionResultTranslator<ValidationProblemError, ControllerResultContext>, ValidationProblemErrorTranslator>();
            services.AddScoped<IActionResultTranslator<ForbidError, ControllerResultContext>, ForbidErrorTranslator>();

            return services;
        }
    }
}
