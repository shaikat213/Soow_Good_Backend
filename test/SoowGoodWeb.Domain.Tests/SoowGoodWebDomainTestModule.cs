using SoowGoodWeb.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SoowGoodWeb;

[DependsOn(
    typeof(SoowGoodWebEntityFrameworkCoreTestModule)
    )]
public class SoowGoodWebDomainTestModule : AbpModule
{

}
