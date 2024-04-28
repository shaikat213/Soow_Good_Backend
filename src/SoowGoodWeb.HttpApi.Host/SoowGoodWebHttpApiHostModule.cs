using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoowGoodWeb.EntityFrameworkCore;
using SoowGoodWeb.MultiTenancy;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;

//using OpenIddict.Validation.AspNetCore;
//using Volo.Abp.Account;
//using Volo.Abp.Account.Web;
//using Volo.Abp.AspNetCore.MultiTenancy;
//using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
//using Volo.Abp.UI.Navigation.Urls;
//using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.EventBus.RabbitMq;
using Autofac.Core;

namespace SoowGoodWeb;

[DependsOn(
    typeof(SoowGoodWebHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    //typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(SoowGoodWebApplicationModule),
    typeof(SoowGoodWebEntityFrameworkCoreModule),
    //typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    //typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)//,
    //typeof(AbpEventBusRabbitMqModule)
    //typeof(AbpAspNetCoreSignalRModule)
)]
public class SoowGoodWebHttpApiHostModule : AbpModule
{
    //public override void PreConfigureServices(ServiceConfigurationContext context)
    //{
    //    PreConfigure<OpenIddictBuilder>(builder =>
    //    {
    //        builder.AddValidation(options =>
    //        {
    //            options.AddAudiences("SoowGoodWeb");
    //            options.UseLocalServer();
    //            options.UseAspNetCore();
    //        });
    //    });
    //}

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        ConfigureConventionalControllers();
        ConfigureAuthentication(context, configuration);
        ConfigureCache(configuration);
        //ConfigureBundles();
        //ConfigureUrls(configuration);
        ConfigureDataProtection(context, configuration, hostingEnvironment);
        ConfigureDistributedLocking(context, configuration);
        ConfigureVirtualFileSystem(context);
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);

        //context.Services.AddTransient<BroadcastHub>();

        //Configure<AbpSignalROptions>(options =>
        //{
        //    options.Hubs.Add(
        //        new HubConfig(
        //            typeof(BroadcastHub),
        //            "/notify",
        //            hubOptions =>
        //            {
        //                //Additional options
        //                hubOptions.LongPolling.PollTimeout = TimeSpan.FromSeconds(30);
        //            }
        //        )
        //    );
        //});
        //context.Services.AddSignalR();
    }

    private void ConfigureCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "SoowGoodWeb:"; });
    }
    //private void ConfigureAuthentication(ServiceConfigurationContext context)
    //{
    //    context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
    //}

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = "SoowGoodWeb";
            });
    }
    //private void ConfigureBundles()
    //{
    //    Configure<AbpBundlingOptions>(options =>
    //    {
    //        options.StyleBundles.Configure(
    //            BasicThemeBundles.Styles.Global,
    //            bundle =>
    //            {
    //                bundle.AddFiles("/global-styles.css");
    //            }
    //        );
    //    });
    //}

    //private void ConfigureUrls(IConfiguration configuration)
    //{
    //    Configure<AppUrlOptions>(options =>
    //    {
    //        options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
    //        options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"]?.Split(',') ?? Array.Empty<string>());

    //        options.Applications["Angular"].RootUrl = configuration["App:ClientUrl"];
    //        options.Applications["Angular"].Urls[AccountUrlNames.PasswordReset] = "account/reset-password";
    //    });
    //}

    private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<SoowGoodWebDomainSharedModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}SoowGoodWeb.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<SoowGoodWebDomainModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}SoowGoodWeb.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<SoowGoodWebApplicationContractsModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}SoowGoodWeb.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<SoowGoodWebApplicationModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}SoowGoodWeb.Application"));
            });
        }
    }

    private void ConfigureConventionalControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(SoowGoodWebApplicationModule).Assembly);
        });
    }

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"],
            new Dictionary<string, string>
            {
                {"SoowGoodWeb", "SoowGoodWeb API"}
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "SoowGoodWeb API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
    }

    private void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment)
    {
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("SoowGoodWeb");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "SoowGoodWeb-Protection-Keys");
        }
    }

    private void ConfigureDistributedLocking(
        ServiceConfigurationContext context,
        IConfiguration configuration)
    {
        context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        {
            var connection = ConnectionMultiplexer
                .Connect(configuration["Redis:Configuration"]);
            return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        });
    }
    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(configuration["App:CorsOrigins"]?
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(o => o.RemovePostFix("/"))
                        .ToArray() ?? Array.Empty<string>())
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
        context.Services.AddSignalR();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        //if (!env.IsDevelopment())
        //{
        //    app.UseErrorPage();
        //}

        //app.Use(async (httpContext, next) =>
        //    {
        //        var path = httpContext.Request.Path;
        //        if (
        //            (path.StartsWithSegments("/notify")))
        //        {   
        //        }

        //        await next();
        //    });

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        //app.UseAbpOpenIddictValidation();
        app.UseEndpoints(endpoints =>
         {
             endpoints.MapHub<BroadcastHub>("/notify");
            //,
            //        hubOptions =>
            //        {
            //            //Additional options
            //            hubOptions.LongPolling.PollTimeout = TimeSpan.FromSeconds(5);
            //        });
         });
        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "SoowGoodWeb API");

            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            c.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            c.OAuthScopes("SoowGoodWeb");
        });

        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}