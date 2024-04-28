using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoowGoodWeb.Data;
using Volo.Abp.DependencyInjection;

namespace SoowGoodWeb.EntityFrameworkCore;

public class EntityFrameworkCoreSoowGoodWebDbSchemaMigrator
    : ISoowGoodWebDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSoowGoodWebDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SoowGoodWebDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SoowGoodWebDbContext>()
            .Database
            .MigrateAsync();
    }
}
