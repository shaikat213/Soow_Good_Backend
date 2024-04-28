using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SoowGoodWeb.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SoowGoodWebDbContextFactory : IDesignTimeDbContextFactory<SoowGoodWebDbContext>
{
    public SoowGoodWebDbContext CreateDbContext(string[] args)
    {
        SoowGoodWebEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SoowGoodWebDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SoowGoodWebDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SoowGoodWeb.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
