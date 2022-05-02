using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicsContracts
{
    public interface ICureLogic
    {
        List<CureViewModel> Read(CureBindingModel model);
        void CreateOrUpdate(CureBindingModel model);
        void Delete (CureBindingModel model);
    }
}
