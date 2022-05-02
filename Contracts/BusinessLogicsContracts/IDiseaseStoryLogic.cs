using Contracts.BindingModels;
using Contracts.ViewModels;

namespace Contracts.BusinessLogicsContracts
{
    public interface IDiseaseStoryLogic
    {
        List<DiseaseStoryViewModel> Read(DiseaseStoryBindingModel model);
        void CreateOrUpdate(DiseaseStoryBindingModel model); 
        void Delete(DiseaseStoryBindingModel model);
    }
}
