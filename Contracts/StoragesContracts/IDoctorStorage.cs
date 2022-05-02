using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.StoragesContracts
{
    public interface IDoctorStorage
    {
        List<DoctorViewModel> GetFullList();
        List<DoctorViewModel> GetFilteredList(DoctorBindingModel model);
        DoctorViewModel GetElement(DoctorBindingModel model);
        void Insert(DoctorBindingModel model);
        void Update(DoctorBindingModel model);
        void Delete(DoctorBindingModel model);
    }
}
