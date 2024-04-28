using Volo.Abp.Settings;

namespace SoowGoodWeb.Settings;

public class SoowGoodWebSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SoowGoodWebSettings.MySetting1));
    }
}
