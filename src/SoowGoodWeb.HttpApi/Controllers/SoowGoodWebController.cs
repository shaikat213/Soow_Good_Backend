using SoowGoodWeb.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SoowGoodWeb.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SoowGoodWebController : AbpControllerBase
{
    protected SoowGoodWebController()
    {
        LocalizationResource = typeof(SoowGoodWebResource);
    }
}
