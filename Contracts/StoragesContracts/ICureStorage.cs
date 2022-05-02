using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.StoragesContracts
{
    public interface ICureStorage
    {
        List<CureViewModel> GetFullList();
        List<CureViewModel> GetFilteredList(CureBindingModel model);
        CureViewModel GetElement(CureBindingModel model);
        void Insert(CureBindingModel model);
        void Update(CureBindingModel model);
        void Delete(CureBindingModel model);
    }
}
