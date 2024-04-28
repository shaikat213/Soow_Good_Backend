using SoowGoodWeb.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SoowGoodWeb.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SoowGoodWebEntityFrameworkCoreModule),
    typeof(SoowGoodWebApplicationContractsModule)
    )]
public class SoowGoodWebDbMigratorModule : AbpModule
{

}
