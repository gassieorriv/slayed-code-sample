using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlayedLifeAPI.Handler;
using SlayedLifeCore.Configuration;
using SlayedLifeCore.Preferences;
using SlayedLifeCore.Shop;
using SlayedLifeCore.Social;
using SlayedLifeCore.Social.Google;
using SlayedLifeCore.Stripe;
using SlayedLifeCore.Support;
using SlayedLifeCore.Users;
using SlayedLifeCore.Web.Configuration;
using SlayedLifeRepo.Context;
using SlayedLifeRepo.Preferences;
using SlayedLifeRepo.Repository;
using SlayedLifeRepo.Shop;
using SlayedLifeRepo.Social;
using SlayedLifeRepo.Support;
using SlayedLifeRepo.Users;
using SlayedLifeServices.Preferences;
using SlayedLifeServices.Shop;
using SlayedLifeServices.Social;
using SlayedLifeServices.Social.Google;
using SlayedLifeServices.Stripe;
using SlayedLifeServices.Support;
using SlayedLifeServices.Users;
using System;
using System.Collections.Generic;

namespace SlayedLifeAPI.Configuration.DependencyInjection
{
    public static class RepositoryRegistry
    {
        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ConnectedSocialAccountRepository>().As<IConnectedSocialAccountRepository>();
            builder.RegisterType<PreferenceRepository>().As<IPreferenceRepository>();
            builder.RegisterType<UserPreferenceRepository>().As<IUserPreferenceRepository>();
            builder.RegisterType<SupportNoteRepository>().As<ISupportNoteRepository>();
            builder.RegisterType<UserPaymentAccountRepository>().As<IUserPaymentAccountRepository>();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<StateTaxRepository>().As<IStateTaxRepository>();
            builder.RegisterType<UserScheduleRepository>().As<IUserScheduleRepository>();
        }

        public static void RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<FacebookHttpClient>().As<IFacebookHttpClient>();
            builder.RegisterType<GoogleHttpClient>().As<IGoogleHttpClient>();
            builder.RegisterType<StripeHttpClient>().As<IStripeHttpClient>();
            builder.RegisterType<SocialMediaService>().As<ISocailMediaService>();
            builder.RegisterType<PreferenceService>().As<IPreferenceService>();
            builder.RegisterType<SupportNoteService>().As<ISupportNoteService>();
            builder.RegisterType<StripeService>().As<IStripeService>();
            builder.RegisterType<UserPaymentAccountService>().As<IUserPaymentAccountService>();
            builder.RegisterType<ShopService>().As<IShopService>();
            builder.RegisterType<UserScheduleService>().As<IUserScheduleService>();
        }

        public static void RegisterMapper(this ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(x => typeof(Profile).IsAssignableFrom(x) && !x.IsAbstract && x.IsPublic)
                .As<Profile>();

            builder.Register(c =>
                new MapperConfiguration(cfg =>
                {
                    foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    {
                        cfg.AddProfile(profile);
                    }
                })
            )
            .AsSelf()
            .SingleInstance();

            builder.Register(c =>
            {
                var componentContext = c.Resolve<IComponentContext>();
                var config = componentContext.Resolve<MapperConfiguration>();
                return config.CreateMapper();
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }

        public static void RegisterAuthorizationHandler(this ContainerBuilder builder)
        {
            builder.RegisterType<EngageAuthorizeHandler>().As<IAuthorizationHandler>();
        }
    }

    public static class ContextRegistry 
    {
        private static bool IsDbContextConfigured(this ServiceProvider serviceProvider) =>
            serviceProvider.GetService<SlayedAPIContext>() != null;

        public static void RegisterContexts(this ContainerBuilder builder, IServiceCollection service, IConfiguration configuration)
        {
            if (!service.BuildServiceProvider().IsDbContextConfigured())
            {
                builder.RegisterType<SlayedAPIContext>().InstancePerLifetimeScope();
            }
            builder.RegisterType<CoreConfiguration>()
                .As<ICoreConfiguration>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();
        }
    }
}
