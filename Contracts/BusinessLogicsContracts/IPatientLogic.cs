using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicsContracts
{
    public interface IPatientLogic
    {
        List<PatientViewModel> Read(PatientBindingModel model);
        void CreateOrUpdate(PatientBindingModel model);
        void Delete(PatientBindingModel model);
    }
}
