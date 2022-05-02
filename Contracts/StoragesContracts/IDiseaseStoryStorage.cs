using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.StoragesContracts
{
    public interface IDiseaseStoryStorage
    {
        List<DiseaseStoryViewModel> GetFullList();
        List<DiseaseStoryViewModel> GetFilteredList(DiseaseStoryBindingModel model);
        DiseaseStoryViewModel GetElement(DiseaseStoryBindingModel model);
        void Insert(DiseaseStoryBindingModel model);
        void Update(DiseaseStoryBindingModel model);
        void Delete(DiseaseStoryBindingModel model);
    }
}
