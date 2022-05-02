using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.StoragesContracts
{
    public interface IPatientStorage
    {
        List<PatientViewModel> GetFullList();
        List<PatientViewModel> GetFilteredList(PatientBindingModel model);
        PatientViewModel GetElement(PatientBindingModel model);
        void Insert(PatientBindingModel model);
        void Update(PatientBindingModel model);
        void Delete(PatientBindingModel model);
    }
}
