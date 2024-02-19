using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlayedLifeAPI.Configuration;
using SlayedLifeAPI.Configuration.DependencyInjection;
using SlayedLifeAPI.Handler;

namespace SlayedLifeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        protected IServiceCollection Services { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.Services = services;
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Custom Scheme";
                options.DefaultChallengeScheme = "Custom Scheme";
            }).AddCustomAuth(o => { });
            services.AddApplicationInsightsTelemetry();
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<RequiredHeaderParameter>();
            });
            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("authorized", policy =>
                    policy.Requirements.Add(new EngageHandlerRequirement()));
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterRepositories();
            builder.RegisterContexts(Services, Configuration);
            builder.RegisterServices();
            builder.RegisterMapper();
            builder.RegisterAuthorizationHandler();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Slayed Life API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
