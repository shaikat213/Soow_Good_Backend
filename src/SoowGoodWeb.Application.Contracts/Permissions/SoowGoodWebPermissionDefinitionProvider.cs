using SoowGoodWeb.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SoowGoodWeb.Permissions;

public class SoowGoodWebPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SoowGoodWebPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SoowGoodWebPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SoowGoodWebResource>(name);
    }
}
