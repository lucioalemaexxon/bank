using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Autofac;
using Bank.Loans.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using MediatR;
using System.Text.Json.Serialization;
using Bank.Auth.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using Bank.Auth.Infrastructure.Bootstrap.Extensions.ApplicationBuilder;
using Microsoft.Extensions.Hosting;
using Bank.Auth.Application.Features.Users.Queries;

namespace Bank.Auth.Infrastructure.Bootstrap
{
    public class ApplicationStartup
    {
        public IConfiguration configuration { get; }
        private readonly IWebHostEnvironment env;

        public ApplicationStartup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMicroserviceHealthChecks();
            services.AddSwagger("v1", "Bank.Auth.Api", "v1");
            services.ConfigureResponseCompression();
            services.AddHttpContextAccessor();
            services.AddCorsConfiguration();
            services.AddEFConfiguration(configuration);
            services.AddMediatR(typeof(FindAllUsersQuery).Assembly);
            services.AddLoanDemoInitializer();
            services.AddControllers(o =>
            {
                o.Filters.Add(new ProducesResponseTypeAttribute(400));
                o.Filters.Add(new ProducesResponseTypeAttribute(500));
            }).AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddConfigurationAutofac(configuration, env);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseMicroserviceHealthChecks();
            app.UseResponseCompression();
            app.UseMicroserviceExampleSwagger();
            app.UseInitializer();
            app.UseCorsConfiguration();
            app.UseExceptionHandler(errorPipeline =>
            {
                errorPipeline.UseExceptionHandlerMiddleware(this.configuration.GetValue("AppSettings:IncludeErrorDetailInResponse", false));
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}

