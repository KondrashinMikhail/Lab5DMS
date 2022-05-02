using Contracts.BindingModels;
using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Contracts.ViewModels;

namespace BusinessLogic.BusinessLogics
{
    public class DiseaseStoryLogic : IDiseaseStoryLogic
    {
        private readonly IDiseaseStoryStorage _storage;
        public DiseaseStoryLogic(IDiseaseStoryStorage storage) => _storage = storage;
        public List<DiseaseStoryViewModel> Read(DiseaseStoryBindingModel model)
        {
            if (model == null) return _storage.GetFullList();
            if (model.Id.HasValue) return new List<DiseaseStoryViewModel> { _storage.GetElement(model) };
            return _storage.GetFilteredList(model);
        }
        public void CreateOrUpdate(DiseaseStoryBindingModel model)
        {
            if (model.Id.HasValue) _storage.Update(model);
            else _storage.Insert(model);
        }
        public void Delete(DiseaseStoryBindingModel model)
        {
            var element = _storage.GetElement(new DiseaseStoryBindingModel { Id = model.Id });
            if (element == null) throw new Exception("История болезни не найдена");
            _storage.Delete(model);
        }
    }
}
