using System.Threading.Tasks;

namespace SoowGoodWeb.Data;

public interface ISoowGoodWebDbSchemaMigrator
{
    Task MigrateAsync();
}
