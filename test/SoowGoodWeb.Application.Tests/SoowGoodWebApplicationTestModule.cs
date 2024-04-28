using Volo.Abp.Modularity;

namespace SoowGoodWeb;

[DependsOn(
    typeof(SoowGoodWebApplicationModule),
    typeof(SoowGoodWebDomainTestModule)
    )]
public class SoowGoodWebApplicationTestModule : AbpModule
{

}
