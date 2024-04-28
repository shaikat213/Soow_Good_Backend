using System;
using System.Collections.Generic;
using System.Text;
using SoowGoodWeb.Localization;
using Volo.Abp.Application.Services;

namespace SoowGoodWeb;

/* Inherit your application services from this class.
 */
public abstract class SoowGoodWebAppService : ApplicationService
{
    protected SoowGoodWebAppService()
    {
        LocalizationResource = typeof(SoowGoodWebResource);
    }
}
