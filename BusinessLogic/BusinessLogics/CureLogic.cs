using Contracts.BindingModels;
using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Contracts.ViewModels;

namespace BusinessLogic.BusinessLogics
{
    public class CureLogic : ICureLogic
    {
        private readonly ICureStorage _storage;
        public CureLogic(ICureStorage storage) => _storage = storage;
        public List<CureViewModel> Read(CureBindingModel model)
        {
            if (model == null) return _storage.GetFullList();
            if (model.Id.HasValue) return new List<CureViewModel> { _storage.GetElement(model) };
            return _storage.GetFilteredList(model);
        }
        public void CreateOrUpdate(CureBindingModel model)
        {
            var element = _storage.GetElement(new CureBindingModel { CureName = model.CureName });
            if (element != null && element.Id != model.Id) throw new Exception("Уже есть лекарство с таким названием");
            if (model.Id.HasValue) _storage.Update(model);
            else _storage.Insert(model);
        }
        public void Delete(CureBindingModel model)
        {
            var element = _storage.GetElement(new CureBindingModel { Id = model.Id });
            if (element == null) throw new Exception("Лекарство не найдено");
            _storage.Delete(model);
        }
    }
}
