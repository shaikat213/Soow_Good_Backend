using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SoowGoodWeb;

[Dependency(ReplaceServices = true)]
public class SoowGoodWebBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SoowGoodWeb";
}
