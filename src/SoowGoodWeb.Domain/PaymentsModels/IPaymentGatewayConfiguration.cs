using Volo.Abp.DependencyInjection;

namespace SoowGoodWeb.PaymentsModels
{
    public interface IPaymentGatewayConfiguration : ITransientDependency
    {
        bool IsActive { get; }
    }
}