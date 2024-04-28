using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SoowGoodWeb.Data;

/* This is used if database provider does't define
 * ISoowGoodWebDbSchemaMigrator implementation.
 */
public class NullSoowGoodWebDbSchemaMigrator : ISoowGoodWebDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
