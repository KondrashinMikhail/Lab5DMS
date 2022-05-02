using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicsContracts
{
    public interface IDoctorLogic
    {
        List<DoctorViewModel> Read(DoctorBindingModel model); 
        void CreateOrUpdate(DoctorBindingModel model); 
        void Delete(DoctorBindingModel model);
    }
}
