using RulesEngine.BusinessRules;

namespace RulesEngine
{
    public interface IPackageSystem
    {
        void GeneratePackageSlip(IOrder order, PackageSlipType packageSlipType);
    }
}
